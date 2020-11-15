using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<Type> PrefferedFoodTypes =>
            new List<Type>() { typeof(Vegetable), typeof(Meat) };

        public override double WeightMultiplier => 0.30;

        

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
