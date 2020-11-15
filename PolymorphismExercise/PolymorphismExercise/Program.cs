using PolymorphismExercise.Models;
using System;
using System.IO;
using System.Linq;

namespace PolymorphismExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            var CarInfo =Console.ReadLine().Split().ToArray();

            var TruckInfo =Console.ReadLine().Split().ToArray();

            var BusInfo =Console.ReadLine().Split().ToArray();

            Car car = new Car(double.Parse(CarInfo[1]), double.Parse(CarInfo[2]),int.Parse(CarInfo[3]));

            Truck truck= new Truck(double.Parse(TruckInfo[1]), double.Parse(TruckInfo[2]),int.Parse(TruckInfo[3]));

            Bus bus=new Bus(double.Parse(BusInfo[1]), double.Parse(BusInfo[2]), int.Parse(BusInfo[3]));

            int n =int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command =Console.ReadLine().Split().ToArray();

                try
                {
                    if (command[1] == "Car")
                    {
                        if (command[0] == "Drive")
                        {
                            car.Drive(double.Parse(command[2]),false);


                        }
                        else
                        {
                            car.Refuel(double.Parse(command[2]));
                        }


                    }
                    else if(command[1]=="Truck")
                    {
                        if (command[0] == "Drive")
                        {
                            truck.Drive(double.Parse(command[2]), false);


                        }
                        else
                        {
                            truck.Refuel(double.Parse(command[2]));
                        }



                    }
                    else
                    {
                        if (command[0]== "DriveEmpty")
                        {
                            bus.Drive(double.Parse(command[2]), true);
                        }
                        else if (command[0]=="Drive")
                        {
                            bus.Drive(double.Parse(command[2]), false);
                        }
                        else
                        {
                            bus.Refuel(double.Parse(command[2]));
                        }
                            
                    }

                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }
              



            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
