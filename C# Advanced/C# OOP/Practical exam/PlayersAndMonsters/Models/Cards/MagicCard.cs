using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        //Has 5 damage points and 80 health points.

            private  const int MagicCardDamageAtStart = 5;
            private  const int MagicCardHealthpoints = 80;

        public MagicCard(string name) 
            : base(name, MagicCardDamageAtStart, MagicCardHealthpoints)
        {
        }
    }
}
