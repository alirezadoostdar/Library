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
        var book = new Book
        {
            Title = dto.Title,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
        };
        var result = await _repository.AddAsync(book);
        return result.Id;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
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

    public Task UpdateAsync(int id, UpdateBookDto dto)
    {
        throw new NotImplementedException();
    }
}
