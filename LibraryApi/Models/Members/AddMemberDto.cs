namespace LibraryApi.Models.Members;

public record AddMemberDto(
    string Name,
    string Family,
    string Address,
    string PhoneNumber,
    int MembershipNumber,
    DateTime MembershipDate);
