using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Models
{
    public class Product : IProduct
    {
        public string ibm 
        {
            get { return this.ibm; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();

                }
                 this.ibm = value;
            } 
        }

        public decimal price {
            get { return this.price; }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException();
                }
                this.price = value;
            }
        }

       

        

        public int Quantity
        {
            get { return this.Quantity; }
            private set {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.Quantity = value;
                }
        }

        public Product(string ibm, decimal price,int quantity)
        {
            this.ibm = ibm;
            this.price = price;
            this.Quantity = quantity;

        }

        


    }
}
