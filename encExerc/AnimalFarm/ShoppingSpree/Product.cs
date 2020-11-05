using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
   public class Product
    {
        private string name;
        private double cost;

        public Product(string name,double cost)
        {
            this.Name = name;
            this.Cost = cost;

        }

        public string Name 
        { 
            get { return this.name; }
            set 
            {
                CommonGeneral.ValidateName(value);
                this.name = value;


            }
        }

        public double Cost
        {
            get { return this.cost; }
            set
            {
                CommonGeneral.ValidateMoney(value);
                this.cost = value;


            }
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
