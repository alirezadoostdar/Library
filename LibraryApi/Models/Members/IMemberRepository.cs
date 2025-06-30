using LibraryApi.Models.Persons;

namespace LibraryApi.Models.Members;

public interface IMemberRepository
{
    void Add(AddMemberDto dto);
    void Update(AddMemberDto dto);
    void Delete(int id);
    Member? GetById(int id);
    List<GetMemberDto> GetAll();
}
public class MemberRepository : IMemberRepository
{
    public readonly ApplicationDbContext _context;

    public MemberRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(AddMemberDto dto)
    {
        var member = new Member
        {
            Name = dto.Name,
            Family = dto.Family,
            MembershipNumber = dto.MembershipNumber,
            MembershipDate = dto.MembershipDate,
            ContactInfo = new ContactInfo
            {
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
            }
        };
        _context.Members.Add(member);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetMemberDto> GetAll()
    {
        return _context.Members.Select(x => new GetMemberDto(
            x.Id,
            x.Name,
            x.Family,
            x.ContactInfo.Address,
            x.ContactInfo.PhoneNumber,
            x.MembershipNumber,
            x.MembershipDate)).ToList();
    }

    public Member? GetById(int id)
    {
        return _context.Members.Find(id);
    }

    public void Update(AddMemberDto dto)
    {
        throw new NotImplementedException();
    }
}
