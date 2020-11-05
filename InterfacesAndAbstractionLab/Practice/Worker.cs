using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
   abstract class Worker
    {
        public abstract void Work();

        public abstract int Salary { get; set; }

        public virtual void Slack()
        {
            Console.WriteLine("Slackingg");
        }
        public abstract void GetSalary();

        public void NewHoliday()
        {

        }
    }
}
