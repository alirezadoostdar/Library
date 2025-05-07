using Library.Models.Books;

namespace Library.Models.Categories;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();

    public override string ToString()
    {
        var str = $"|Id: {Id} | Title: {Title}\n" +
                   "------------------------------------";
        return str;
    }
}
