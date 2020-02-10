using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    class PlayerRepository : IPlayerRepository
    {
        Dictionary<string, IPlayer> playersByUsername;

        public PlayerRepository()
        {
            playersByUsername = new Dictionary<string, IPlayer>();
        }

        public int Count => playersByUsername.Count;

        public IReadOnlyCollection<IPlayer> Players => this.playersByUsername.Values;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            else if (playersByUsername.ContainsValue(player))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            playersByUsername.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            IPlayer searchedPlayer = null;
            foreach (var player in playersByUsername.Values)
            {
               if ( player.Username == username)
                {
                    searchedPlayer = player;
                }
            }
            return searchedPlayer;
        }

        public bool Remove(IPlayer player)
        {
           if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
           return playersByUsername.Remove(player.Username);
        }
    }
}
