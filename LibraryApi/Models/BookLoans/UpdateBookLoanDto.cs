namespace LibraryApi.Models.BookLoans;

public class UpdateBookLoanDto
{
    public DateTime MustReturnDate { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
}
