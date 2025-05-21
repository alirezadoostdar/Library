namespace LibraryApi.Models.Books;

public class AddBookDto
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public int Pages { get; set; }
    public int CategoryId { get; set; }

}
