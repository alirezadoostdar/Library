namespace LibraryApi.Models.Members;

public record UpdateMemberDto(
    int id,
    string Name,
    string Family,
    string Address,
    string PhoneNumber,
    int MembershipNumber,
    DateTime MembershipDate);
