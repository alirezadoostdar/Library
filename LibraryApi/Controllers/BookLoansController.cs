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

    [HttpPost]
    public void Add(AddBookLoanDto dto)
    {
        var member = new BookLoan();
        member.RegisterDate = DateTime.UtcNow;
        member.MustReturnDate = DateTime.UtcNow;
        member.ReturnDate = DateTime.UtcNow;
        member.BookId = dto.BookId;
        member.MemberId = dto.MemberId;
        _bookLoansRepository.Add(member);
    }
}
