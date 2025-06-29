

namespace LibraryApi.Models.Persons;

public abstract class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public ContactInfo ContactInfo { get; set; }
}
public class ContactInfo
{
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}
