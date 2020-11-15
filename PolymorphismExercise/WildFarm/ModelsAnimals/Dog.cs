using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override ICollection<Type> PrefferedFoodTypes =>
            new List<Type>() { typeof(Meat) };

        public override double WeightMultiplier => 0.40;

        

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
