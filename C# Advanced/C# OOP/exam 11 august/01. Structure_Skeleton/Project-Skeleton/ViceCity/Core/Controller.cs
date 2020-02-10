using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly Queue<IGun> guns;
        private readonly INeighbourhood neighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new Queue<IGun>();
            this.neighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;
            if(nameof(Pistol) == type)
            {
                gun = new Pistol(name);
            }
            else if (nameof(Rifle) == type)
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }
            this.guns.Enqueue(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0)
            {
                return $"There are no guns in the queue!";
            }
            else if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(guns.Peek());
                return $"Successfully added {guns.Dequeue().Name} to the Main Player: Tommy Vercetti";
            }
            else
            {
                foreach (var civilPlayer in civilPlayers)
                {
                    if (civilPlayer.Name == name)
                    {
                        civilPlayer.GunRepository.Add(guns.Peek());
                        return $"Successfully added {guns.Dequeue().Name} to the Civil Player: {name}";
                    }
                }
                return "Civil player with that name doesn't exists!";
            }
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int mainPlayerLifePoints = mainPlayer.LifePoints;
            int civilLifePoints = civilPlayers.Select(x => x.LifePoints).Sum();
            int totalCivils = civilPlayers.Count;
            this.neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            int mainPlayerLifePointsAfterTheFight = mainPlayer.LifePoints;
            int civilLifePointsAfterFight = civilPlayers.Select(x => x.LifePoints).Sum();
            int aliveCivils = civilPlayers.Count(p => p.IsAlive);
            string message = null;

            if (mainPlayerLifePoints == mainPlayerLifePointsAfterTheFight
                && civilLifePoints == civilLifePointsAfterFight)
            {
                message = "Everything is okay!";
            }
            else
            {
                message = "A fight happened:" + Environment.NewLine;
                message += $"Tommy live points: {mainPlayerLifePointsAfterTheFight}!" + Environment.NewLine;
                message += $"Tommy has killed: {totalCivils - aliveCivils} players!" + Environment.NewLine;
                message += $"Left Civil Players: {aliveCivils}!";
            }
            return message;
        }
    }
}
