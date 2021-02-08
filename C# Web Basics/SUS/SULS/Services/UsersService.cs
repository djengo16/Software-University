using SULS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SULS.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DoRegister(string username, string password, string email)
        {
            dbContext.Users.Add(new User
            {
                Username = username,
                Password = ComputeHash(password),
                Email = email,
            });
            dbContext.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var userToReturn = dbContext.Users.FirstOrDefault(x => x.Username == username
            && x.Password == ComputeHash(password));

            return userToReturn?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !dbContext.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !dbContext.Users.Any(x => x.Username == username);
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
    }
}
