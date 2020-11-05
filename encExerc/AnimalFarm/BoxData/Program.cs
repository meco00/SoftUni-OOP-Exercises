using System;
using System.IO;

namespace BoxData
{
   public class Program
    {
       public static void Main(string[] args)
        {
            double length =double.Parse(Console.ReadLine());
            double width =double.Parse(Console.ReadLine());
            double height =double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                box.Calculations();
               


            }
            catch (ArgumentException ax)
            {

                Console.WriteLine(ax.Message);
            }
        }
    }
}
