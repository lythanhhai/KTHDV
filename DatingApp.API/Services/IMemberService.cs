using DatingApp.API.DTOs;
namespace DatingApp.API.Services 
{
    public interface IMemberService 
    {
        public List<MemberDto> GetMembers();

        public MemberDto GetMemberByUsername(string username);
    }
}