namespace LibraryApi.Models.Books;

public interface IBookRepository
{
    void Add(Book book);
    List<GetBookDto> GetAll();
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

    public List<GetBookDto> GetAll()
    {
        return _context.Books.Select(x => new GetBookDto
        {
            Tilte = x.Title,
            Author = x.Author,
            Description = x.Description,
        }).ToList();
    }
}
