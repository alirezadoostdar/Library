using FluentValidation.Validators;
using LibraryApi.Models.Authors;
using LibraryApi.Models.Persons;
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

    [HttpGet("{id:int}")]
    public GetAuthorDto GetById(int id)
    {
        var author = _authorRepository.FindById(id);
        if (author == null)
            throw new NullReferenceException("Author not found");

        var authorDto = new GetAuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Family = author.Family,
            Birthday = author.Birthday,
            Address = author.ContactInfo.Address,
            PhoneNumber = author.ContactInfo.PhoneNumber,
            LicenseNumber = author.LicenseNumber,
        };
        return authorDto;

    }

    [HttpGet]
    public List<GetAuthorDto> GetAll()
    {
        return _authorRepository.GetAll();
    }

    [HttpPost]
    public void Add(AddAuthorDto dto)
    {
        Author author = new Author();
        author.ContactInfo = new ContactInfo();
        author.Name = dto.Name;
        author.Family = dto.Family;
        author.Birthday = dto.Birthday;
        author.LicenseNumber = dto.LicenseNumber;
        author.ContactInfo.Address = dto.Address;
        author.ContactInfo.PhoneNumber = dto.PhoneNumber;

        _authorRepository.Add(author);
    }

    [HttpPut("{id:int}")]
    public void Update(int id, UpdateAuthorDto dto)
    {
        var author = _authorRepository.FindById(id);
        if (author == null) 
            throw new NullReferenceException(nameof(author));
        author.Name = dto.Name;
        author.Family = dto.Family;
        author.Birthday = dto.Birthday;
        author.LicenseNumber = dto.LicenseNumber;
        author.ContactInfo.Address = dto.Address;
        author.ContactInfo.PhoneNumber = dto.PhoneNumber;
        _authorRepository.Update(author);
    }
}
