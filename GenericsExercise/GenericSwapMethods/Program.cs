using System;
using System.IO;
using System.Linq;
using System.Collections;

namespace GenericSwapMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            Box2<int> collection = new Box2<int>();
            for (int i = 0; i < n; i++)
            {
                collection.Add(int.Parse(Console.ReadLine()));

            }
            int[] indexes =Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Box2<int>.SwapElements(collection.GenericList, firstIndex, secondIndex);

            Console.WriteLine(collection);
            
        }
    }
}
