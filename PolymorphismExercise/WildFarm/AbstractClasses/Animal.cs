using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;

namespace WildFarm
{
    public abstract class Animal:IFeedable,IAnimal,ISoundable
    {
        private const string INVALID_FOOD_TYPE = "{0} does not eat {1}!";

        public  string Name { get;  }
        public  double Weight { get; private set; }
        public  int FoodEaten { get; private set; }

        public abstract ICollection<Type> PrefferedFoodTypes { get; }

        public abstract double WeightMultiplier { get; }

        protected Animal(string name,double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;

        }



        public void Feed(IFood food)
        {
            if (!this.PrefferedFoodTypes.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(INVALID_FOOD_TYPE,this.GetType().Name,food.GetType().Name));

            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }

    }
}
