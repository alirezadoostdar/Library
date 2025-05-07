using Library.Interfaces;
using Library.Models.Books;
using Library.Models.Categories;

namespace Library.Controllers;

public class BookController
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }

    public void Add(AddBookDto book)
    {
        var newBook = new Book()
        {
            Id = 0,
            Title = book.Title,
            Author = book.Author,
            Code = book.Code,
            CategoryId = book.CategoryId,
        };
        _repository.Add(newBook);
    }

    public List<ListBookDto> GetAll()
    {
        var list = _repository.GetAll().Select(b => new ListBookDto()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,      
            Category = b.Category.Title
        }).ToList();
        return list;
    }
}
