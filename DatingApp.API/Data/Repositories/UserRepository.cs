using DatingApp.API.Data.Entities;
using DatingApp.API.Data.Repositories;

namespace DatingApp.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public void CreateUser(Users user)
        {
            _context.User.Add(user);
        }

        public void DeleteUser(Users user)
        {
            _context.User.Remove(user);
            // _context.SaveChanges();
        }

        public Users GetUserById(int id)
        {
            return _context.User.FirstOrDefault(user => user.id == id);
        }

        public Users GetUserByUsername(string username)
        {
            return _context.User.FirstOrDefault(user => user.Username == username);
        }

        public List<Users> GetUsers()
        {
            return _context.User.ToList();
        }

        public bool IsSaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateUser(Users user)
        {
            _context.User.Update(user);
        }
    }
}