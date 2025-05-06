using Library.Models.Books;

namespace Library.Interfaces;

public interface IBookRepository
{
    void Add (Book book);
    void Update (Book book);
    void Delete (Book book);
    Book Get(int id);
    IEnumerable<Book> GetAll();
}
