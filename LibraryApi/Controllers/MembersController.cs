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

        [HttpPut]
        public void Add(AddMemberDto dto)
        {
            _memberRepository.Add(dto);
        }
    }
}
