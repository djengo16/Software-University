using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var currentGun in mainPlayer.GunRepository.Models)
            {
                foreach (var currentCivil in civilPlayers)
                {
                    while (currentCivil.IsAlive && currentGun.CanFire)
                    {
                        currentCivil.TakeLifePoints(currentGun.Fire());
                    }
                    if (!currentGun.CanFire)
                    {
                        break;
                    }
                }
            }
            
            foreach (var currentCivil in civilPlayers)
            {
                if (!currentCivil.IsAlive)
                {
                    continue;
                }
                foreach (var currentCivilGun in currentCivil.GunRepository.Models)
                {

                    while (mainPlayer.IsAlive && currentCivilGun.CanFire)
                    {
                        mainPlayer.TakeLifePoints(currentCivilGun.Fire());
                    }
                    if (!currentCivilGun.CanFire)
                    {
                        break;
                    }
                }
            }
        }
    }
}
