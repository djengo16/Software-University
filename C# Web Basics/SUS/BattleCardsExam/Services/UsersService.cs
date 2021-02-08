using BattleCardsExam.Data;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;

namespace BattleCardsExam.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;


        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(string username, string password, string email)
        {

            var user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.db.Users.Any(x => x.Username == username);
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

            var user = this.db.Users.FirstOrDefault(x => x.Username == username);
            if (user?.Password != ComputeHash(password))
            {
                return null;
            }

            return user.Id;
        }

        public void AddCardToCollection(int cardId, string userId)
        {
            if (db.UserCards.Any(x => x.CardId == cardId && x.UserId == userId))
            {
                return;
            }
            db.UserCards.Add(new UserCard
            {
                CardId = cardId,
                UserId = userId,
            });
            db.SaveChanges();
        }

        public void RemoveCardFromCollection(int cardId, string userId)
        {
            
            var userCard = db.UserCards.FirstOrDefault(x => x.CardId == cardId && x.UserId == userId);
            if (userCard == null)
            {
                return;
            }
            db.UserCards
                .Remove(userCard);
            db.SaveChanges();
        }
    
    }
}
