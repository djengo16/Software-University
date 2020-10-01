﻿using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => this.players;

        public void Add(IPlayer model)
        {
            if(model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.players.Add(model);
        }

        public IPlayer FindByName(string name) => 
            this.players.FirstOrDefault(p => p.Username == name);

        public bool Remove(IPlayer model) 
            => this.players.Remove(model);
        
    }
}