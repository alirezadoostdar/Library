
using Library.Interfaces;
using Library.Models;
using Library.Models.Books;

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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void Update(Book book)
    {
        throw new NotImplementedException();
    }
}
