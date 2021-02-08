using BattleCardsExam.ViewModels;
using System.Collections.Generic;

namespace BattleCardsExam.Services
{
    public interface ICardsService
    {
        public int CreateCard(CardInputModel card);

        public ICollection<CardViewModel> GetAll();

        public ICollection<CardViewModel> GetUserCollection(string userId);
    }
}
