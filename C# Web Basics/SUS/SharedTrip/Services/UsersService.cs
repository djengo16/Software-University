using Microsoft.EntityFrameworkCore.Internal;
using SharedTrip.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext database;

        public UsersService(ApplicationDbContext database)
        {
            this.database = database;
        }
        public void DoRegister(string username, string password, string email)
        {
            var userToCreate = new User
            {
                Username = username,
                Password = ComputeHash(password),
                Email = email,
            };

            database.Users.Add(userToCreate);
            database.SaveChanges();
        }

        public bool IsEmailAvailable(string email)
        {
            return !database.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !database.Users.Any(x => x.Username == username);
        }
        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }

        public string GetUserId(string username, string password)
        {

            var pass = ComputeHash(password);
            var user = database.Users.FirstOrDefault(x => x.Username == username && x.Password == pass);


            return user?.Id;
        }
    }
}
