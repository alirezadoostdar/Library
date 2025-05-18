namespace LibraryApi.Models.Books;

public class UpdateBookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Code { get; set; }
    public int CategoryId { get; set; }
}
