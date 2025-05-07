
namespace Library.Models.Books;

public class AddBookDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Code { get; set; }
    public int CategoryId { get; set; }
}
