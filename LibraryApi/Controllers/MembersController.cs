using LibraryApi.Models.Members;
using LibraryApi.Models.Persons;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/Members")]
    public class MembersController : Controller
    {
        public readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet("{id:int}")]
        public GetMemberDto GetById(int id)
        {
            var member = _memberRepository.GetById(id);
            if (member == null)
                throw new Exception("member not found");
            return new GetMemberDto
            (
                member.Id,
                member.Name,
                member.Family,
                member.ContactInfo.Address,
                member.ContactInfo.PhoneNumber,
                member.MembershipNumber,
                member.MembershipDate
            );
        }

        [HttpGet]
        public List<GetMemberDto> GetAll()
        {
            return _memberRepository.GetAll();
        }

        [HttpPost]
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
            _memberRepository.Add(member);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _memberRepository.Delete(id);
        }

        [HttpPut("{id:int}")]
        public void Update(int id,  UpdateMemberDto dto)
        {
            var member = _memberRepository.GetById(id);
            if (member == null)
                throw new Exception("member not found");
            member.Name = dto.Name;
            member.Family = dto.Family;
            member.MembershipNumber = dto.MembershipNumber;
            member.MembershipDate = dto.MembershipDate;
            member.ContactInfo.PhoneNumber = dto.PhoneNumber;
            member.ContactInfo.Address = dto.Address;
            _memberRepository.Update(member);
        }

    }
}
