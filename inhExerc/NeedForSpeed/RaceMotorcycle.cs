using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;

        public override double FuelConsumption => DefaultFuelConsumption;

        public RaceMotorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        {
        }
    }
}