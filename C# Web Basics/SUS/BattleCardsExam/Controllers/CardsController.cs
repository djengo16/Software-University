using BattleCardsExam.Data;
using BattleCardsExam.Services;
using BattleCardsExam.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCardsExam.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;
        private readonly IUsersService usersService;

        public CardsController(ICardsService cardsService, IUsersService usersService)
        {
            this.cardsService = cardsService;
            this.usersService = usersService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var allCards = cardsService.GetAll();
            return this.View(allCards);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse Add(CardInputModel card)
        {
            
            //•	Has Name – a string(required); min.length: 5, max.length: 15
            if(card.Name.Length < 5 || card.Name.Length > 15 || string.IsNullOrEmpty(card.Name))
            {
                return this.Error("Name is required and it should be between 5 and 15 symbols!");
            }
            //•	Has ImageUrl – a string(required)
            if (string.IsNullOrEmpty(card.Image))
            {
                return this.Error("Image is required!");
            }
            //•	Has Keyword – a string(required)
            if (string.IsNullOrEmpty(card.Keyword))
            {
                return this.Error("Keyword is required!");
            }
            //•	Has Attack – an int(required); cannot be negative
            if (card.Attack < 0)
            {
                return this.Error("Attack cannot be negative!");
            }
            //•	Has Health – an int(required); cannot be negative
            if(card.Health < 0)
            {
                return this.Error("Health cannot be negative!");
            }
            //•	Has a Description – a string with max length 200(required)
            if (string.IsNullOrEmpty(card.Description))
            {
                return this.Error("Description is required!");
            }
            if(card.Description.Length > 200)
            {
                return this.Error("Description cannot reach 200 symbols!");
            }
            int cardId = cardsService.CreateCard(card);

            usersService.AddCardToCollection(cardId, this.GetUserId());

            return this.Redirect("/Cards/All");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View(cardsService.GetUserCollection(this.GetUserId()));
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            usersService.AddCardToCollection(cardId, this.GetUserId());
            return this.Redirect("/Cards/Collection");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            usersService.RemoveCardFromCollection(cardId, this.GetUserId());
            return this.Redirect("/Cards/Collection");
        }
    }
}
