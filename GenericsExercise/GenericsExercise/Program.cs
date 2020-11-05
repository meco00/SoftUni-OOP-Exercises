using System;
using System.Collections.Generic;
using System.IO;

namespace GenericsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            List<Box<double>> list = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                Box<double> currentBox = new Box<double>(double.Parse(Console.ReadLine()));
                list.Add(currentBox);

            }

            double toCompare =double.Parse(Console.ReadLine());
            int countOfComperators = Box<double>.CountOfComparers(list, toCompare);
            Console.WriteLine(countOfComperators);

        }
    }
}
