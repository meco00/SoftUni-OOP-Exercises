using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<Type> PrefferedFoodTypes =>
            new List<Type>() { typeof(Meat) };

        public override double WeightMultiplier => 1.00;

       

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
