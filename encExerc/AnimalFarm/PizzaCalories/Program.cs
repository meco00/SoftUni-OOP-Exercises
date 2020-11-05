using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] pizzaInp =Console.ReadLine().Split().ToArray();
            string[] doughInp =Console.ReadLine().Split().ToArray();

            var doughValidate = doughInp.Skip(1).ToArray();

            try
            {
                Dough dough = new Dough(doughValidate[0], doughValidate[1], int.Parse(doughValidate[2]));

                Pizza pizza = new Pizza(pizzaInp[1], dough);
                
                    

                string command = string.Empty;
                while ((command=Console.ReadLine())!="END")
                {
                    var input = command.Split().ToArray();
                    if (input[0] == "Topping")
                    {
                        input = input.Skip(1).ToArray();

                        Topping topping = new Topping(input[0],double.Parse(input[1]));

                        pizza.AddTopings(topping);




                    }

                }


                Console.WriteLine(pizza.ToString());

            }
            catch (Exception ae)
            {

                Console.WriteLine(ae.Message);
            }

           



             


        }
    }
}
