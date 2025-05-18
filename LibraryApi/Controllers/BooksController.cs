using LibraryApi.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public void Add(AddBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Code = dto.Code,
                CategoryId = dto.CategoryId,
            };
            _bookRepository.Add(book);
        }

        [HttpGet]
        public List<GetBookDto> GetBooks()
        {
            return _bookRepository.GetAll();
        }

        [HttpPut("{id:int}")]
        public void Put(int id, UpdateBookDto dto)
        {
            var book = _bookRepository.GetById(id);
            if (book != null)
            {
                _bookRepository.Update(book);
            }
        }
    }
}
