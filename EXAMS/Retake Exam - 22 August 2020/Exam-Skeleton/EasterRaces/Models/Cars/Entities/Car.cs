using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsepower;
        private double cubicCentimeters;

        private readonly int minHP;
        private readonly int maxHP;


        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.minHP = minHorsePower;
            this.maxHP = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;

        }


        public string Model 
        {
            get { return this.model; }
            private set
            {
                if (String.IsNullOrEmpty(value)||value.Length<4)
                {
                    
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,value,4));

                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get { return this.horsepower; }
            private set
            {
                if (!(value >=minHP && value<=maxHP))
                {
                    
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));

                }
                this.horsepower = value;
            }
        }

        public double CubicCentimeters
        {
            get { return this.cubicCentimeters; }
            private set
            {
               
                this.cubicCentimeters = value;
            }
        }

       

        

        public double CalculateRacePoints(int laps)
        {
            //cubic centimeters / horsepower * laps

            return cubicCentimeters / (double)horsepower * (double)laps;
        }
    }
}
