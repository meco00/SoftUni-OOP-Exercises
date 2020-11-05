using System;
using System.IO;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] createcmd = Console.ReadLine().Split(new string[] { "Push ", ", "," " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> myStack = new Stack<int>(createcmd);

            string input =Console.ReadLine();
            while (input!="END")
            {
               
                if (input.StartsWith("Push"))
                {
                    createcmd = input.Split(new string[] { "Push ", ", ", " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                      myStack.Push(createcmd);

                }
                else if (input.StartsWith("Pop"))
                {
                    myStack.Pop();

                }



                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join("\n",myStack));
        }
    }
}
