using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Contracts.Core;
using WildFarm.Contracts.Factories;

namespace WildFarm.Contracts
{
    
    public class Engine : IEngine
    {
        private readonly AnimalFactory animalFactory;

        private readonly FoodFactory foodFactory;


        private readonly ICollection<Animal> animals;

        public Engine()
        {
            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
            animals = new HashSet<Animal>();
        }
        public void Run()
        {



            Animal animal = null;
            Food food = null;

            int count = 0;


            string input = Console.ReadLine();
            while (input != "End")
            {
                var command = input.Split().ToArray();

                string type = command[0];


                if (count % 2 == 0)
                {
                    string name = command[1];
                    double weight = double.Parse(command[2]);
                    try
                    {
                        animal = animalFactory.Create(name, type, weight, command);

                        Console.WriteLine(animal.ProduceSound());
                        animals.Add(animal);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);

                    }



                }
                else
                {
                    int quantity = int.Parse(command[1]);
                    try
                    {
                        food = foodFactory.CreateFood(type, quantity);
                        animal.Feed(food);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);

                    }


                }

                count++;
                input = Console.ReadLine();
            }

            PrintAnimalsInfo();
        }

        private void PrintAnimalsInfo()
        {
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
