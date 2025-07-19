using Library.Application.Dtos.Books;

namespace Library.Application.Interfaces;
public interface IBookService
{
    Task<GetBookDto> GetByIdAsync(int id);
    Task<int> AddAsync(AddBookDto dto);
    Task UpdateAsync(int id, UpdateBookDto dto);
    Task DeleteAsync(int id);
    Task<List<GetBookDto>> GetAllAsync();
}
