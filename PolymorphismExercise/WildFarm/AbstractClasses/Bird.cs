using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public abstract class Bird:Animal
    {
        protected Bird(string name, double weight, double wingsize):base(name,weight)
        {
           
            this.WingSize = wingsize;
          
        }
        public double WingSize { get;}

        public override string ToString()
        {
            return base.ToString()+ $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
