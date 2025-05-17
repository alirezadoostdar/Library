namespace LibraryApi.Models.Books;

public interface IBookRepository
{
    void Add(Book book);
}

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }
}
