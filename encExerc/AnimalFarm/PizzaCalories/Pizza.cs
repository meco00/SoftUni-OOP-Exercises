using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PizzaCalories
{
   public class Pizza
    {

        private string name;
        private Dough dough;
        private readonly ICollection<Topping> topings;


        private Pizza()
        {
            topings = new List<Topping>();
           
        }

        public Pizza(string name, Dough dought) :this()
        {
            this.Name = name;
            dough = dought;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrEmpty(value)||value.Length>15)
                {
                    throw new Exception(String.Format(CommonGeneral.INVALID_PIZZA_NAME));
                }
                this.name = value;
            }

        }



        public void AddTopings(Topping topping)
        {
            topings.Add(topping);
            if (topings.Count>10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");

            }
           



           

        }


        public double CalculateTotalCalories()
        {
            double totalSum = 0;

            totalSum += dough.Calories;

            totalSum += topings.Sum(x => x.Calculate());

            return totalSum;

        }


        public override string ToString()
        {
            return $"{this.Name} - {CalculateTotalCalories():f2} Calories.";
        }

    }
}
