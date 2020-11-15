using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;

namespace WildFarm.Contracts.Factories
{
    class AnimalFactory
    {
        public Animal Create(string name,string type,double weight,string[] args)
        {
            Animal animal=null;
            if (type == "Owl" || type == "Hen")
            {


                double wingSize = double.Parse(args[3]);

                if (type == "Owl")
                {
                    animal = new Owl(name, weight, wingSize);

                }
                else if(type == "Hen")
                {
                    animal = new Hen(name, weight, wingSize);
                }



            }
            else if (type == "Cat" || type == "Tiger")
            {


                string livingRegion = args[3];
                string breed = args[4];

                if (type == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);

                }
                else if(type == "Tiger")
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                }



            }
            else if (type == "Mouse" || type == "Dog")
            {


                string livingRegion = args[3];


                if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);

                }
                else if(type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }



            }
            else
            {
                throw new InvalidOperationException(ExceptionMessage.InvalidAnimalType);
            }


            return animal;
        }
    }
}
