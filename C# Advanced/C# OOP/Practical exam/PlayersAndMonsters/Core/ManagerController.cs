namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private IPlayerFactory playerFactory;

        private ICardRepository cardRepository;
        private ICardFactory cardFactory;
        private IBattleField battleField;

        

        public ManagerController(IPlayerRepository playerRepository,
            IPlayerFactory playerFactory, ICardRepository cardRepository
            , ICardFactory cardFactory,IBattleField battleField)
        {
            this.playerRepository = playerRepository;
            this.playerFactory = playerFactory;
            this.cardRepository = cardRepository;
            this.cardFactory = cardFactory;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);

            playerRepository.Add(player);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

        }

        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);
            cardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var user = playerRepository.Find(username);
            var card = cardRepository.Find(cardName);
            user.CardRepository.Add(card);
            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepository.Find(attackUser);
            var enemy = playerRepository.Find(enemyUser);

            battleField.Fight(attacker, enemy);
            return String.Format(ConstantMessages.FightInfo,attacker.Health,enemy.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username
                    , player.Health, player.CardRepository.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(String.Format(ConstantMessages.CardReportInfo
                        , card.Name, card.DamagePoints));
                }
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
