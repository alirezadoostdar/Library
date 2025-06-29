using LibraryApi.Models.Persons;

namespace LibraryApi.Models.Members;

public class Member : Person
{
    public int MembershipNumber { get; set; }
    public DateTime MembershipDate { get; set; }
}
