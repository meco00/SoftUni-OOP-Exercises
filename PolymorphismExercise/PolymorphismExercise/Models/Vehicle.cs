using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PolymorphismExercise.Models
{
    public abstract class Vehicle:IVehicle
    {
        public double fuelquantity { get;  private set; }

        public virtual double fueelConsumptPerKm { get; private set; }

      

       

        double tankCapacity;

        public Vehicle(double quantity, double fuelcons,double tankcapacity)
        {
            this.tankCapacity = tankcapacity;
            FuelQuantity = quantity;

            

            
            this.fueelConsumptPerKm = fuelcons;
            
        }
        public double FuelQuantity
        {
            get => this.fuelquantity;
            protected set
            {
                if (value > this.tankCapacity)
                {
                    this.fuelquantity = 0;
                }
                else
                {
                    this.fuelquantity = value;
                }

            }
        }







        public virtual void Drive(double km,bool hasAirConditioning)
        {

            double consumption = 0; ;

            if (hasAirConditioning)
            {
                double decrease = this.fueelConsumptPerKm - 1.4D;
                consumption = this.fuelquantity - (decrease * km);
                

            }
            else
            {
                consumption = this.fuelquantity - (fueelConsumptPerKm  * km);
            }

            if (consumption<0)
            {
                throw new Exception($"{GetType().Name} needs refueling");

            }
            else
            {
                this.fuelquantity -= (fueelConsumptPerKm * km);
                Console.WriteLine($"{GetType().Name} travelled {km} km");
                
            }

        }

        public virtual void Refuel(double quantity)
        {
            // decimal quantityRefueling = quantity * (decimal)refuelDecrease;

            //this.fuelquantity += Math.Round(quantityRefueling, MidpointRounding.ToEven);

            if (quantity <= 0)
            {
                throw new Exception("Fuel must be a positive number");

            }

            if (quantity+this.fuelquantity>tankCapacity)
            {
                throw new Exception($"Cannot fit {quantity} fuel in the tank");

            }

            this.fuelquantity += quantity;


           

        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Math.Round(fuelquantity,2,MidpointRounding.AwayFromZero):f2}";
        }


    }
}
