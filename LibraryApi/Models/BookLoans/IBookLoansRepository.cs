using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models.BookLoans;


public interface IBookLoansRepository
{
    void Add(BookLoan bookLoans);
    void Update(BookLoan bookLoans);
    void Delete(int id);
    BookLoan? GetById(int id);
}
public class BookLoansRepository : IBookLoansRepository
{
    public readonly ApplicationDbContext _context;

    public BookLoansRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(BookLoan bookLoans)
    {
        _context.BookLoans.Add(bookLoans);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var bookLoan = _context.BookLoans.Find(id);
        _context.BookLoans.Remove(bookLoan);
    }

    public BookLoan? GetById(int id)
    {
        return _context.BookLoans
            .Include(x => x.Member)
            .Include(x => x.Book)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(BookLoan bookLoans)
    {
        throw new NotImplementedException();
    }
}
