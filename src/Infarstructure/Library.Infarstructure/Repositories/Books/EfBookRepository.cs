using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Infarstructure.Repositories.Books;

public class EfBookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public EfBookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Book> AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        var book = await _context.Books.
            Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        return book;
    }

    public Task<Book> UpdateAsync(Book book)
    {
        throw new NotImplementedException();
    }
}
