using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Contracts
{
    interface IStock
    {
        public ICollection<IProduct> products { get; }
    }
}
