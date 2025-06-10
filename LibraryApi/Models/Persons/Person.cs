using LibraryApi.Models.ContactInfos;

namespace LibraryApi.Models.Persons
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
