namespace LibraryApi.Models.Authors;

public class UpdateAuthorDto 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public int LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime Birthday { get; set; }
}
