using LibraryApi.Models.Authors;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/Authors")]
public class AuthorsController : Controller
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorsController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpPost]
    public void Add(AddAuthorDto dto)
    {
        Author author = new Author
        {
            Name = dto.
        }
        _authorRepository.Add()
    }
}
