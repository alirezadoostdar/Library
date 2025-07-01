using LibraryApi.Models.Books;
using LibraryApi.Models.Members;

namespace LibraryApi.Models.BookLoans;

public class BookLoans
{
    public int Id { get; set; }

    public DateTime RegisterDate { get; set; }
    public DateTime MustReturnDate { get; set; }
    public DateTime ReturDate { get; set; }
    public int MemeberId { get; set; }
    public Member Member { get; set; }

    public int BookId { get; set; }
    public Book Book{ get; set; }
}
