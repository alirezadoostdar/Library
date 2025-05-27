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
        public void Update(int id, UpdateBookDto dto)
        {
            var book = _bookRepository.GetById(id);
            if (book != null)
            {
                book.Title = dto.Title;
                book.Author = dto.Author;
                book.Code = dto.Code;
                book.CategoryId = dto.CategoryId;
                _bookRepository.Update(book);
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book is not null)
            {
                _bookRepository.Delete(book);
            }
        }

        [HttpPatch("{id:int}")]
        public void UpdateRate(int id, UpdateBookRateDto dto)
        {
            var book = _bookRepository.GetById(id);
            if(book is not null)
            {
                _bookRepository.Update(book);   
            }

        }

        [HttpGet("{id:int}")]
        public GetBookDto GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            var bookDto = new GetBookDto()
            {
                Id = book.Id,
                Tilte = book.Title,
                Author = book.Author,
                Code = book.Code,
                AgeGroup = book.Category.AgeGroup.Title,
                Category = book.Category.Title,
                Rates = book.Rates.Select(x => x.Value).ToList()
            };
            return bookDto;
        }

        [HttpGet("/get-by-Code/{code}")]
        public GetBookDto? GetByCode(string code)
        {
            return _bookRepository.GetByCode(code);
        }

        [HttpGet("/get-list-by-rate")]
        public List<GetBookByRateDto> GetlistByRate()
        {
            return _bookRepository.GetListByRate();
        }
    }
}
