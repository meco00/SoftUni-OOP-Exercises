using FootBallTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace FootBallTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;


        private Team()
        {
            players = new List<Player>();
        }


        public Team(string name):this()
        {
            this.Name = name;
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                CommonGeneral.ValidateNames(value);

                this.name = value;
            }
        }

        public int Rating => this.players.Count>0 ?
            (int)Math.Round(players.Average(x=>x.Stat.OverallSkill))
            :0;


        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var currentPlayer = players.FirstOrDefault(x => x.Name == playerName);

            if (!players.Remove(currentPlayer))
            {
                throw new Exception(String.Format(CommonGeneral.INVALID_PLAYER_REMOVE, playerName, this.Name));

            }

        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
