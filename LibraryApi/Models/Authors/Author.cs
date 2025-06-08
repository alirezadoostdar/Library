using LibraryApi.Models.ContactInfos;

namespace LibraryApi.Models.Authors;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public DateTime Birthday { get; set; }
    public ContactInfo ContactInfo { get; set; }

}
