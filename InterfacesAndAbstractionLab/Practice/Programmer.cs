using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Practice
{
    class Programmer : Worker
    {
        public override int Salary { get; set; }

        public override void Work()
        {
            Console.WriteLine("ne rabotq dneska");
        }
      
    }
}
