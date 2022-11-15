using DatingApp.API.DTOs;
namespace DatingApp.API.Services
{
    public interface IAuthService
    {
        string Login(AuthUserDto authUserDto);

        string Register(RegisterUserDto registerUserDto);
    }
}