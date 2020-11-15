using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favFood) : base(name, favFood)
        {
            this.Type = "MEEOW";
        }

        public override string Type  { get; }

       
    }
}
