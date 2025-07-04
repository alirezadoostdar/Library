using LibraryApi.Models.Books;
using LibraryApi.Models.Persons;

namespace LibraryApi.Models.Authors;

public class Author : Person
{
    public int LicenseNumber { get; set; }
    public DateTime Birthday { get; set; }
    public List<Book> Books { get; set; }

}
