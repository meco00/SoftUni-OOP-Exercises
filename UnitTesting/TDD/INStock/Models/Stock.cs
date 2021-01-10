using INStock.Contracts;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock.Models
{
    public class Stock : IStock
    {
        public ICollection<IProduct> products { get; }

        public Stock()
        {
            products = new List<IProduct>();
        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            this.products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            var checker = this.products.FirstOrDefault(x => x.ibm == product.ibm);

            if (checker is null)
            {
                return false;

            }

            return true;

            
        }

        public IProduct Find(int index)
        {
            IProduct current = this.products.ToArray()[index];

            if (current is null)
            {
                throw new IndexOutOfRangeException();

            }
            return current;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = this.products.FirstOrDefault(x => x.ibm == label);

            if (product is null)
            {
                throw new ArgumentException();

            }

            return product;
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal min, decimal max)
        {
            List<IProduct> collection = products.Where(x => x.price >= min && x.price <= max).ToList();

            if (collection.Count==0)
            {
                return new List<IProduct>();

            }

            return collection;

        }


    }
}
