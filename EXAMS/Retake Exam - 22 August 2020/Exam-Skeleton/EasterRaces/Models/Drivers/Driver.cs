using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Contracts
{
   public class Driver : IDriver
    {

        private string name;
        
        

        public Driver(string name)
        {
            this.Name = name;

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

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                if (!(Car==null))
                {
                    return true;
                }
                return false;
            }
        } 

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);

            }

            this.Car = car;
           
        }

        public void WinRace()
        {
            NumberOfWins++;
            
            
        }
    }
}
