using Library.Models.Categories;

namespace Library.Models.Books;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Code { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}

