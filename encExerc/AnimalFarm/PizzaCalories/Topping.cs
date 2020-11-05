using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MIN_RANGE = 1;
        private const int MAX_RANGE = 50;

        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private double weight;
        private string name;


        public Topping(string name,double weght)
        {
            this.Name = name;
            this.Weight = weght;


        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (!this.IsValidName(value))
                {
                    throw new Exception(String.Format(CommonGeneral.INVALID_TOPPING_TYPE, value));
                }

                this.name = value;


            }
        }


        public double Weight
        {
            get
            {
                return this.weight;

            }
            private set
            {
                if (value<1||value>50)
                {
                    throw new Exception(String.Format(CommonGeneral.INVALID_TOPPING_RANGE,this.Name,MIN_RANGE,MAX_RANGE));

                }
                this.weight = value;

            }

        }

        

        private bool IsValidName(string value)
        {
            var current = value.ToLower();

            if (current != "meat" && current != "veggies" && current != "cheese" && current != "sauce")
            {
                return false;
            }
            return true;
        }

        public double Calculate()
        {
            double type=0;
            string currentName = name.ToLower();
            switch (currentName)
            {
                case "meat":
                    type = Meat;
                    break;
                case "veggies":
                    type = Veggies;
                    break;
                case "cheese":
                    type = Cheese;
                    break;
                case "sauce":
                    type = Sauce;
                    break;

                default:
                    break;
            }


            double sum = type * weight*2;

            return sum;
        }


    }
}
