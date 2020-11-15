using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;

namespace WildFarm
{
    public abstract class Food:IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;

        }

        public int Quantity { get; }
    }
}
