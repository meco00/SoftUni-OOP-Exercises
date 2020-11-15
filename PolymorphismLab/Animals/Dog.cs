using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Cat
    {
        public Dog(string name, string favFood) : base(name, favFood)
        {
            this.Type = "DJAAF";
        }

        public override string Type { get; }

    }
}
