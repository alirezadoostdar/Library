namespace LibraryApi.Models.Members;

public record GetMemberDto(
    int id,
    string Name,
    string Family,
    string Address,
    string PhoneNumber,
    int MembershipNumber,
    DateTime MembershipDate);