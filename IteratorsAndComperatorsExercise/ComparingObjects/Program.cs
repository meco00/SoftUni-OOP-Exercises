using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ComparingObjects
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            string input = Console.ReadLine();
            while (input!="END")
            {

                var command = input.Split().ToArray();
                string name = command[0];
                int age =int.Parse(command[1]);
                string town = command[2];

                Person currentPerson = new Person(name, age, town);

                list.Add(currentPerson);


                input = Console.ReadLine();
            }

            int index =int.Parse(Console.ReadLine())-1;

            var temp = list[index];
            int equalCount = 0;

            foreach (var item in list)
            {
                if (temp.CompareTo(item)==0)
                {
                    equalCount++;

                }


            }
            if (equalCount==1)
            {
                Console.WriteLine("No matches");

            }
            else
            {
                Console.WriteLine($"{equalCount} {list.Count-equalCount} {list.Count}");


            }



        }
    }
}
