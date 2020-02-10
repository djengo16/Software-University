using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public abstract class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
         if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            //•	If the player is a beginner,
            //increase his health with 40 points and increase all damage points of all cards for the user with 30.
            if (attackPlayer is Players.Beginner)
            {
                attackPlayer.Health += 40;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
                BoostPlayer(attackPlayer);
                BoostPlayer(enemyPlayer);
                while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
                {
                    enemyPlayer.TakeDamage(GetTotalDamagePoints(attackPlayer.CardRepository));
                    if (enemyPlayer.IsDead)
                    {
                        break;
                    }
                    attackPlayer.TakeDamage(GetTotalDamagePoints(enemyPlayer.CardRepository));
                }
            }
        }

        private IPlayer BoostPlayer(IPlayer player)
        {
            player.Health += player
                .CardRepository
                .Cards
                .Select(x => x.HealthPoints)
                .Sum();
            return player;
        }
        private int GetTotalDamagePoints(ICardRepository cardRepo)
        {
            int total = 0;
            foreach (var card in cardRepo.Cards)
            {
                total += card.DamagePoints;
            }
            return total;
        }
    }

}
