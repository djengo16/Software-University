using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    class CardRepository : ICardRepository
    {
        Dictionary<string, ICard> cardsByName;
        public CardRepository()
        {
            this.cardsByName = new Dictionary<string, ICard>();
        }

        public int Count => this.cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardsByName.Values;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            else if (cardsByName.ContainsValue(card))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            cardsByName.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            ICard searched = null;
            foreach (var card in cardsByName.Values)
            {
                if (card.Name == name)
                {
                    searched = card;
                }
            }
            return searched;
        }

        public bool Remove(ICard card)
        {
           if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            return cardsByName.Remove(card.Name);
        }
    }
}
