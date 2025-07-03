namespace LibraryApi.Models.BookLoans;

public class AddBookLoanDto
{
    public DateTime MustReturnDate { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
}
