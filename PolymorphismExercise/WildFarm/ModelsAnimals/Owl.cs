using System;
using System.Collections.Generic;
using System.Text;


namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name,double weight,double wingsize):base(name,weight,wingsize)
        {
            

        }


        public override ICollection<Type> PrefferedFoodTypes
            => new List<Type>() { typeof(Meat) };

        public override double WeightMultiplier => 0.25;

       
        
          
       

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
