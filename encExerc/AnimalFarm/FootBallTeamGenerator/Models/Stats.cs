using FootBallTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallTeamGenerator.Models
{
    public class Stats
    {
        private const int MIN_RANGE = 0;
        private const int MAX_RANGE = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;


        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;


        }

        public double OverallSkill => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting)/ 5.0;
        
           

        



        public int Endurance 
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                this.Validation(nameof(Endurance), value);

                this.endurance = value;
                
            }



        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                this.Validation(nameof(Sprint), value);

                this.sprint = value;

            }



        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                this.Validation(nameof(Dribble), value);

                this.dribble = value;

            }



        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                this.Validation(nameof(Passing), value);

                this.passing = value;

            }



        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                this.Validation(nameof(Shooting), value);

                this.shooting = value;

            }



        }




        public void Validation(string name ,int value)
        {
            if (value<MIN_RANGE||value>MAX_RANGE)
            {
                throw new Exception(String.Format(CommonGeneral.INVALID_STAT_INPUT, name, MIN_RANGE, MAX_RANGE));

            }

           

        }
    }
}
