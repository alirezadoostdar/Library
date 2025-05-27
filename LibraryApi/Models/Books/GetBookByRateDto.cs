namespace LibraryApi.Models.Books;

public class GetBookByRateDto
{
    public int Id { get; set; }
    public string Tilte { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public double Rate { get; set; } 
    public string Category { get; set; }
    public string AgeGroup { get; set; }
}
