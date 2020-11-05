using System;
using System.IO;
using System.Linq;

namespace IteratorsAndComperatorsExercise
{
   public class Program
    {
        static void Main(string[] args)
        {
            string[] createcmd =Console.ReadLine().Split(new string[] { "Create"," "},StringSplitOptions.RemoveEmptyEntries).ToArray();
            ListyIterator<string> list = new ListyIterator<string>(createcmd);

            string input =Console.ReadLine();
            while (input!= "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(list.Move());  
                        break;
                    case "Print":
                        list.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());   
                        break;
                    case "PrintAll":
                        list.PrintAll();
                        break;

                    default:
                        break;
                }


                input = Console.ReadLine();
            }


        }
    }
}
