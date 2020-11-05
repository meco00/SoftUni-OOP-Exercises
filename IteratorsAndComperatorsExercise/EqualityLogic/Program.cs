﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EqualityLogic
{
   public class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            int n =int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input =Console.ReadLine().Split().ToArray();
                string name = input[0];
                int age =int.Parse(input[1]);

                var currentPerson = new Person(name, age);

                sortedSet.Add(currentPerson);
                hashSet.Add(currentPerson);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
