using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PolymorphismExercise.Models
{
    public class Bus : Vehicle
    {
        private const double INCREASE_CONSUMPTION = 1.4;
        

        public Bus(double quantity, double fuelcons, double tankcapacity) : base(quantity, fuelcons, tankcapacity)
        {

          
        }


        public override double fueelConsumptPerKm => base.fueelConsumptPerKm+INCREASE_CONSUMPTION;



       

    }
}
