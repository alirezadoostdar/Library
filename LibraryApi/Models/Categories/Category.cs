using LibraryApi.Models.Agegroups;
using LibraryApi.Models.Books;

namespace LibraryApi.Models.Categories;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public byte AgeGroupId { get; set; }
    public AgeGroup  AgeGroup { get; set; }
    public HashSet<Book> Books { get; set; } = new HashSet<Book>();
}
