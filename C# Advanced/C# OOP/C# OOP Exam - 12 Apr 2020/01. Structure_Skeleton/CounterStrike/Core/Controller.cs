using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;

        private readonly IRepository<IPlayer> players;

        private readonly IMap map;

        public Controller()
        {
            this.guns = new GunRepository();

            this.players = new PlayerRepository();

            this.map = new Map();
        }


        public string AddGun(string type, string name, int bulletsCount)
        {
            if(type == "Pistol")
            {
                Pistol pistol = new Pistol(name, bulletsCount);

                guns.Add(pistol);

                return String.Format(OutputMessages.SuccessfullyAddedGun, name);
            }
            else if (type == "Rifle")
            {
                Rifle rifle = new Rifle(name, bulletsCount);

                guns.Add(rifle);

                return String.Format(OutputMessages.SuccessfullyAddedGun, name);
            }

            return ExceptionMessages.InvalidGunType;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player;

            if(type == "Terrorist")
            {
                IGun gun = guns.FindByName(gunName);

                if(gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }

                player = new Terrorist(username, health, armor, gun);

                players.Add(player);

                return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            }

            if (type == "CounterTerrorist")
            {
                IGun gun = guns.FindByName(gunName);

                if (gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }

                player = new CounterTerrorist(username, health, armor, gun);

                players.Add(player);

                return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);

            }

            return ExceptionMessages.InvalidPlayerType;
        }
        public string StartGame()
        {
            ;
            return this.map.Start(players.Models.ToList());
        }

        public string Report()
        {
            List<IPlayer> playersOutput = players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username)
                .ToList();
            
            StringBuilder sb = new StringBuilder();

            foreach (var player in playersOutput)
            {
                sb.AppendLine($"{player.GetType().Name}: {player.Username}");
                sb.AppendLine($"--Health: {player.Health}");
                sb.AppendLine($"--Armor: {player.Armor}");
                sb.AppendLine($"--Gun: {player.Gun.Name}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
