using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();

            string input =Console.ReadLine();

            while (input!= "Beast!")
            {
                var command = Console.ReadLine().Split().ToArray();

                if (input=="Cat")
                {
                   

                    if (command.Length==3)
                    {
                        string name = command[0];
                        int age = int.Parse(command[1]);
                        string gender = command[2];

                        if (age<0)
                        {

                            Console.WriteLine("Invalid input!");

                        }
                        else if (gender!="Male"&&gender!="Female")
                        {

                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            Cat cat = new Cat(name, age, gender);
                            list.Add(cat);
                        }



                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    

                }
                else if (input=="Dog")
                {
                    

                    if (command.Length == 3)
                    {
                        string name = command[0];
                        int age = int.Parse(command[1]);
                        string gender = command[2];

                        if (age < 0)
                        {

                            Console.WriteLine("Invalid input!");

                        }
                        else if (gender != "Male" && gender != "Female")
                        {

                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            Dog dog = new Dog(name, age, gender);
                            list.Add(dog);
                        }



                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else if (input=="Frog")
                {
                   

                    if (command.Length == 3)
                    {
                        string name = command[0];
                        int age = int.Parse(command[1]);
                        string gender = command[2];

                        if (age < 0)
                        {

                            Console.WriteLine("Invalid input!");

                        }
                        else if (gender != "Male" && gender != "Female")
                        {

                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            Frog frog = new Frog(name, age, gender);
                            list.Add(frog);
                        }



                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else if (input=="Tomcat")
                {
                    

                    if (command.Length >= 2)
                    {
                        string name = command[0];
                        int age = int.Parse(command[1]);
                        

                        if (age < 0)
                        {

                            Console.WriteLine("Invalid input!");

                        }
                       
                        else
                        {
                            Tomcat cat = new Tomcat(name, age);
                            list.Add(cat);
                        }



                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else if (input=="Kitten")
                {
                    

                    if (command.Length >= 2)
                    {
                        string name = command[0];
                        int age = int.Parse(command[1]);


                        if (age < 0)
                        {

                            Console.WriteLine("Invalid input!");

                        }

                        else
                        {
                            Kitten cat = new Kitten(name, age);
                            list.Add(cat);
                        }



                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }


                if (command[0]== "Beast!")
                {
                    break;

                }

                input = Console.ReadLine();


            }

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());

            }

        }
    }
}
