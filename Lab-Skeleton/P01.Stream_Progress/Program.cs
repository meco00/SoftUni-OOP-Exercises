using System;
using System.Collections;
using System.Collections.Generic;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            ICollection<ICalculatable> bobo = new List<ICalculatable>();

            bobo.Add(new Music("mecho", "mamo", 200, 10));
            bobo.Add(new File("mecho", 200, 10));

            foreach (var item in bobo)
            {
                Console.WriteLine(item.CalculateCurrentPercent());

            }
        }
    }
}
