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

    public Task<List<GetBookDto>> GetAllAsync()
    {
        throw new NotImplementedException();
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
