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

    public async Task DeleteAsync(int id)
    {
        var book = await GetByIdAsync(id);
         _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var list = await _context.Books
            .Include(x => x.Category)
            .ToListAsync();
        return list;
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        var book = await _context.Books.
            Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        return book;
    }

    public async Task<Book> UpdateAsync(Book book)
    {
       _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return book;
    }
}
