namespace LibraryApi.Models.BookLoans;


public interface IBookLoansRepository
{
    void Add(BookLoan bookLoans);
    void Update(BookLoan bookLoans);
    void Delete(int id);
    BookLoan Get(int id);
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
        throw new NotImplementedException();
    }

    public BookLoan Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(BookLoan bookLoans)
    {
        throw new NotImplementedException();
    }
}
