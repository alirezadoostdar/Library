using LibraryApi.Models.Categories;

namespace LibraryApi.Models.Books;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime PublichDate { get; set; }
    public int Pages { get; set; }
    public byte Rate { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
