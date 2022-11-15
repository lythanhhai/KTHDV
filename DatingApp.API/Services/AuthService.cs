using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using DatingApp.API.Data.Entities;
using DatingApp.API.Data.Repositories;
using DatingApp.API.DTOs;

namespace DatingApp.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        private readonly IMapper _mapper;

        public AuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IMapper mapper)

        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public string Login(AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();

            var currentUser = _userRepository.GetUserByUsername(authUserDto.Username);

            if (currentUser == null)
            {
                throw new UnauthorizedAccessException("Username is invalid.");
            }

            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(authUserDto.Password)
            );

            for (int i = 0; i < currentUser.PasswordHash.Length; i++)
            {
                if (currentUser.PasswordHash[i] != passwordBytes[i])
                {
                    throw new UnauthorizedAccessException("Password is invalid.");
                }
            }

            return _tokenService.CreateToken(currentUser.Username);
        }

        public string Register(RegisterUserDto registerUserDto)
        {
            registerUserDto.Username = registerUserDto.Username.ToLower();
            var currentUser = _userRepository.GetUserByUsername(registerUserDto.Username);
            if (currentUser != null)
            {
                throw new BadHttpRequestException("Username is already existed!");
            }

            using var hmac = new HMACSHA512();
            var passwordBytes = Encoding.UTF8.GetBytes(registerUserDto.Password);
            var newUser = _mapper.Map<RegisterUserDto, Users>(registerUserDto);
                newUser.PasswordSalt = hmac.Key;
                newUser.PasswordHash = hmac.ComputeHash(passwordBytes);
            
            _userRepository.CreateUser(newUser);
            _userRepository.IsSaveChanges();
            return _tokenService.CreateToken(newUser.Username);
        }
    }
}
