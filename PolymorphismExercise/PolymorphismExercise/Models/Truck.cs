using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise.Models
{
    public class Truck : Vehicle
    {
        private const double INCREASE_CONSUMPTION = 1.6;
       // private const double FUEL_DECREASE = 0.95;

        public Truck(double quantity, double fuelcons,double tankcapacity) : base(quantity, fuelcons,tankcapacity)
        {
            
        }

        public override double fueelConsumptPerKm => base.fueelConsumptPerKm+INCREASE_CONSUMPTION;

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity);
            this.FuelQuantity -= (quantity * 0.05) ;
        }




    }
}
