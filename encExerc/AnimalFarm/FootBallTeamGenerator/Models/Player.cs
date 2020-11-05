using FootBallTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private Stats stats;


        public Player(string name,Stats stat)
        {
            this.Name = name;
            this.Stat = stat;



        }


        public Stats Stat
        {
            get { return this.stats; }

            private set
            {
                this.stats = value;
            }
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



    }
}
