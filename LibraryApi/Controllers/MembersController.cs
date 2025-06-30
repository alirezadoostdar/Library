using LibraryApi.Models.Members;
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

        [HttpPut]
        public void Add(AddMemberDto dto)
        {
            _memberRepository.Add(dto);
        }
    }
}
