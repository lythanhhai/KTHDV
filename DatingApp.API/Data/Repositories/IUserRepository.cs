using DatingApp.API.Data.Entities;

namespace DatingApp.API.Data.Repositories
{
    public interface IUserRepository
    {
        List<Users> GetUsers();
        Users GetUserById(int id);
        Users GetUserByUsername(string username);
        void CreateUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(Users user);
        bool IsSaveChanges();
    }
}
