namespace LibraryApi.Models.Books;

public class GetBookDto
{
    public string Tilte { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
