namespace Library.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
