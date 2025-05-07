namespace Library.Models.Books;

public class ListBookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public override string ToString()
    {
        var str = $"|Id: {Id} | Title: {Title}  Author: {Author} Category: {Category} \n" +
                   "------------------------------------";
        return str;
    }
}
