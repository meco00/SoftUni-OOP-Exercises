using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name,double weight,string livingRegion):base(name,weight,livingRegion)
        {
            

        }

        public override ICollection<Type> PrefferedFoodTypes =>
            new List<Type>() { typeof(Fruit), typeof(Vegetable) };


        public override double WeightMultiplier => 0.10;

       

     

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
