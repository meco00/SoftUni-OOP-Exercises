using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public override ICollection<Type> PrefferedFoodTypes =>
            new List<Type>() { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };

        public override double WeightMultiplier => 0.35;

        public Hen(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

       
           
         public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
