
using Library.Interfaces;
using Library.Models;
using Library.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories;

public class EfBookCategory : IBookRepository
{
    private readonly ApplicationDbContext _context;
    public EfBookCategory(ApplicationDbContext context)
    {
            _context = context;
    }
    public void Add(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Delete(Book book)
    {
        throw new NotImplementedException();
    }

    public Book Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetAll()
    {
        var list = _context.Books;
        return list;
    }

    public void Update(Book book)
    {
        throw new NotImplementedException();
    }
}
