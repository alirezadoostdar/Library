using LibraryApi.Models.Books;

namespace LibraryApi.Models.Categories;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public HashSet<Book> Books { get; set; } = new HashSet<Book>();
}
