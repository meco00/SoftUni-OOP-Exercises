using System;
using System.Collections.Generic;
using System.Text;

namespace TupleGenerics
{
   public class Threeuple<Tfirst, Tsecond,Tthird>
    {


        public Threeuple(Tfirst first, Tsecond second,Tthird third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

        public static bool IsDrunk(string info)
        {
            if (info=="drunk")
            {
                return true;

            }
            return false;

        }



        public Tfirst First { get; set; }
        public Tsecond Second { get; set; }
        public Tthird Third { get; set; }

        public override string ToString()
        {
            return $"{First} -> {Second} -> {Third}";


        }


    }
}
