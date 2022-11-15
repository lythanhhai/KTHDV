using DatingApp.API.Services;
using DatingApp.API.DTOs;
using DatingApp.API.Data;
using AutoMapper;
using DatingApp.API.Data.Entities;
using AutoMapper.QueryableExtensions;

namespace DatingApp.API.Services
{
    public class MemberService : IMemberService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MemberService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public MemberDto GetMemberByUsername(string username)
        {
            var user = _context.User.FirstOrDefault(x => x.Username == username);
            if (user == null) return null;
            // return new MemberDto
            // {
            //     Avatar = user.Avatar,
            //     City = user.City,
            //     CreatedAt = user.CreatedAt,
            //     DateOfBirth = user.DateOfBirth,
            //     Email = user.Email,
            //     Gender = user.Gender,
            //     Introduction = user.Introduction,
            //     KnownAs = user.KnownAs,
            //     Username = user.Username,

            // };
            return _mapper.Map<Users, MemberDto>(user);
        }

        public List<MemberDto> GetMembers()
        {
            // C1:
            // var users = _context.User.Select(user => new MemberDto
            // {
            //     Avatar = user.Avatar,
            //     City = user.City,
            //     CreatedAt = user.CreatedAt,
            //     DateOfBirth = user.DateOfBirth,
            //     Email = user.Email,
            //     Gender = user.Gender,
            //     Introduction = user.Introduction,
            //     KnownAs = user.KnownAs,
            //     Username = user.Username,

            // }).ToList();
            // return users;

            // C2
            // var users = _context.User.ToList();
            // return _mapper.Map<List<Users>, List<MemberDto>>(users);

            // C3 
            return _context.User.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToList();
        }
    }
}