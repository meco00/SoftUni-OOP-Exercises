using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
   public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model is null)
            {
                throw new ArgumentException("Cannot add null in Player Repository");

            }

            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.players.FirstOrDefault(x => x.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return this.players.Remove(model);
        }
    }
}
