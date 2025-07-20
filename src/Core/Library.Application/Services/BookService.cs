using Library.Application.Books.Contracts.Exceptions;
using Library.Application.Dtos.Books;
using Library.Application.Dtos.Categories;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddAsync(AddBookDto dto)
    {
        var isDuplicateTitleAndCategory = _repository.IsExistTitleAndCategory(dto.CategoryId, dto.Title);
        if (isDuplicateTitleAndCategory)
            throw new TitleAndCategoryIdDuplicateException();

        var book = new Book
        {
            Title = dto.Title,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
        };
        var result = await _repository.AddAsync(book);
        return result.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        if (book is null)
        {
            // throw exception
        }

        await _repository.DeleteAsync(id);
    }

    public async Task<List<GetBookDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        if(list is null)
            return new List<GetBookDto>();

        return list.Select(x => new GetBookDto(
            x.Id,
            x.Title,
            x.Description,
            new GetCategoryDto(x.Category.Id, x.Category.Title))).ToList();
    }

    public async Task<GetBookDto> GetByIdAsync(int id)
    {
  
        var book = await _repository.GetByIdAsync(id);
        if (book is null)
            throw new KeyNotFoundException();

        var bookDto = new GetBookDto(
            book.Id,
            book.Title,
            book.Description,
            new GetCategoryDto(book.Category.Id, book.Category.Title)
            );

        return bookDto;
    }

    public async Task UpdateAsync(int id, UpdateBookDto dto)
    {
        var book = await _repository.GetByIdAsync(id);
        if (book is null)
            throw new BookNotFoundException();

        var isDuplicateTitleAndCategory = _repository.IsExistTitleAndCategory(dto.CategoryId, dto.Title, dto.Id);
        if (isDuplicateTitleAndCategory)
            throw new TitleAndCategoryIdDuplicateException();

        book.Title = dto.Title;
        book.Description = dto.Description;
        book.CategoryId = dto.CategoryId;

        await _repository.UpdateAsync(book);
    }
}
