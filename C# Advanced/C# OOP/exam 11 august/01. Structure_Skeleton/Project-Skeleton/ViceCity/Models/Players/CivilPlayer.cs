using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int CivilPlayerLifePoints = 50;

        //Has 50 initial life points.

        public CivilPlayer(string name) 
            : base(name,CivilPlayerLifePoints)
        {
        }
    }
}
