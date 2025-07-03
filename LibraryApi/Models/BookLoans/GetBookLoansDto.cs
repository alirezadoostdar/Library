using LibraryApi.Models.Books;
using LibraryApi.Models.Members;

namespace LibraryApi.Models.BookLoans;

public class GetBookLoansDto
{
    public int Id { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime MustReturnDate { get; set; }
    public DateTime? ReturnDate { get; set; } = null;
    public Member Member { get; set; }
    public Book Book { get; set; }
}
