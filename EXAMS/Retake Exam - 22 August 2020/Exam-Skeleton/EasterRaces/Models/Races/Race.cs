using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name ,int laps)
        {
            this.name = name;
            this.laps = laps;
            this.drivers = new List<IDriver>();

        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    //TODO:check if wrong to change value with model
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));

                }
                this.name = value;
            }
        }

        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if (value<1)
                {
                   
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));

                }
                this.laps = value;
            }
        }



        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);

            }
            if (!(driver.CanParticipate))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (drivers.Contains(driver))
            {
                //TODO:CHECK HERE IF DONT GET MAX POINTS

                throw new ArgumentException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));

            }

            this.drivers.Add(driver);

            
        }
    }
}
