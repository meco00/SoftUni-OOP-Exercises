using System;
using System.IO;
using System.Linq;

namespace TupleGenerics
{
    public class Program
    {
        static void Main(string[] args)
        {
            var firstInput =Console.ReadLine().Split().ToArray();
            string firstName = firstInput[0];
            string lastName = firstInput[1];
            string address = firstInput[2];
            string town = firstInput[3];

            Threeuple<string, string,string> firstTuple = new Threeuple<string, string,string>($"{firstName} {lastName}", address,town);

            var secondInput = Console.ReadLine().Split().ToArray();
            string secondName = secondInput[0];
            int amountOfBeer =int.Parse(secondInput[1]);
            string drunkInfo = secondInput[2];

            Threeuple<string, int,bool> secondTuple = new Threeuple<string, int,bool>(secondName, amountOfBeer,Threeuple<string,int,bool>.IsDrunk(drunkInfo));

            var thirdInput = Console.ReadLine().Split().ToArray();
            string thirdName = thirdInput[0];
            double accountBalance =double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];

            Threeuple<string,double,string> thirdTuple = new Threeuple<string, double,string>(thirdName, accountBalance,bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);


        }
    }
}
