using BattleCardsExam.ViewModels;

namespace BattleCardsExam.Services
{
    public interface IUsersService
    {
        public string Create(string username,string password,string email);

        public bool IsUsernameAvailable(string username);

        public bool IsEmailAvailable(string email);

        public string GetUserId(string username,string password);

        public void AddCardToCollection(int cardId,string userId);

        public void RemoveCardFromCollection(int cardId, string userId);
    }
}
