namespace LibraryApi.Models.Books;

public class GetBookDto
{
    public int Id { get; set; }
    public string Tilte { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
