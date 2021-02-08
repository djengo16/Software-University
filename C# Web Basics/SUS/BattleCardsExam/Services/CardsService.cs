using BattleCardsExam.Data;
using BattleCardsExam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCardsExam.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int CreateCard(CardInputModel card)
        {
            var cardToAdd = new Card
            {
                Name = card.Name,
                Attack = card.Attack,
                Health = card.Health,
                Description = card.Description,
                ImageUrl = card.Image,
                Keyword = card.Keyword,
            };

            db.Cards.Add(cardToAdd);
            db.SaveChanges();

            return cardToAdd.Id;
        }

        public ICollection<CardViewModel> GetAll()
        {
            return this.db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                Description = x.Description,
                Image = x.ImageUrl,
                Keyword = x.Keyword,
            }
            ).ToList();
        }

        public ICollection<CardViewModel> GetUserCollection(string userId)
        {
            return this.db.UserCards.Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
                {
                    Attack = x.Card.Attack,
                    Description = x.Card.Description,
                    Health = x.Card.Health,
                    Image = x.Card.ImageUrl,
                    Name = x.Card.Name,
                    Keyword = x.Card.Keyword,
                    Id = x.CardId,
                })
                .ToList();
        }

    }
}
