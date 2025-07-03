using LibraryApi.Models.BookLoans;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/bookloans")]
public class BookLoansController : Controller
{
    public readonly IBookLoansRepository _bookLoansRepository;

    public BookLoansController(IBookLoansRepository bookLoansRepository)
    {
        _bookLoansRepository = bookLoansRepository;
    }

    [HttpGet("{id:int}")]
    public GetBookLoansDto GetById(int id)
    {
        var bookLoan = _bookLoansRepository.GetById(id);
        var getBookLoanDto = new GetBookLoansDto
        {
            Id = bookLoan.Id,
            RegisterDate = bookLoan.RegisterDate,
            MustReturnDate = bookLoan.MustReturnDate,
            ReturnDate = bookLoan.ReturnDate,
        };

        return getBookLoanDto;
    }

    [HttpPost]
    public void Add(AddBookLoanDto dto)
    {
        var member = new BookLoan();
        member.RegisterDate = DateTime.UtcNow;
        member.MustReturnDate = DateTime.UtcNow;
        member.BookId = dto.BookId;
        member.MemberId = dto.MemberId;
        _bookLoansRepository.Add(member);
    }

    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
        _bookLoansRepository.Delete(id);
    }
}
