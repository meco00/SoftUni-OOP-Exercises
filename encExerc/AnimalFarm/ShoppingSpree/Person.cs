using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double cost;
        private readonly ICollection<Product> bag;
        
        private Person()
        {
            bag = new List<Product>();
        }

        public Person(string name,double money):this()
        {
            this.Name = name;
            this.Cost = money;
          

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

        public void CanAfford(Product product)
        {
            
            if (cost>=product.Cost)
            {
                bag.Add(product);
                cost -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");

            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }




        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} - ");

            string toPrint=bag.Count>0? String.Join(", ", bag): "Nothing bought";

            sb.Append(toPrint);

            return sb.ToString().TrimEnd();
        }
    }
}
