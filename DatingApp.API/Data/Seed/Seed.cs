using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using DatingApp.API.Data.Entities;

namespace DatingApp.API.Data.Seed
{
    public static class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (context.User.Any()) return;
            var usersText = File.ReadAllText("Data/Seed/User.json");
            var users = JsonSerializer.Deserialize<List<Users>>(usersText);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@$$w0rd1"));
                user.PasswordSalt = hmac.Key;
                user.CreatedAt = DateTime.Now;
                context.User.Add(user);

            }

            context.SaveChanges();
        }
    }
}