using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise.Models
{
    public class Car : Vehicle
    {
        private const double INCREASE_CONSUMPTION = 0.9;
        

        public Car(double quantity, double fuelcons, double tankcapacity) : base(quantity, fuelcons, tankcapacity)
        {

           
        }

        public override double fueelConsumptPerKm => base.fueelConsumptPerKm+INCREASE_CONSUMPTION;


    }
    }

