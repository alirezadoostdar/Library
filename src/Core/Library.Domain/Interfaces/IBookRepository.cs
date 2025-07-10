using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookRepository
{
    Task<Book> GetByIdAsync(int id);
    Task<Book> AddAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task DeleteAsync(int id);
    Task<IEnumerable<Book>> GetAllAsync();
}