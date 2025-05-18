using LibraryApi.Models.Categories;

namespace LibraryApi.Models.Books;

public interface IBookRepository
{
    void Delete(Book book);    
    void Add(Book book);
    List<GetBookDto> GetAll();
    void Update(Book book);
    Book? GetById(int id);
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

    public void Delete(Book book)
    {
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    public List<GetBookDto> GetAll()
    {
        return _context.Books.Select(x => new GetBookDto
        {
            Tilte = x.Title,
            Author = x.Author,
            Code = x.Code,
        }).ToList();
    }

    public Book? GetById(int id)
    {
        return _context.Books.Find(id);
    }

    public void Update(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }
}
