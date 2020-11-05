using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> persons;
        private readonly ICollection<Product> products;

        public Engine()
        {
            persons = new List<Person>();
            products = new List<Product>();

        }

      
        public void Run()
        {
            try
            {
                ValidatePersonInput();
                ValidateProductInput();
                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    var currentCommand = command.Split().ToArray();

                    var peopleName = currentCommand[0];
                    var productName = currentCommand[1];

                    CanBuy(peopleName, productName);



                }

                foreach (var item in persons)
                {
                    Console.WriteLine(item.ToString());

                }
            }
            catch (Exception ae)
            {

                Console.WriteLine(ae.Message);
            }

           
            



            






        }



        public void ValidatePersonInput()
        {
            var personInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var item in personInput)
            {
                 var currentPerson=item.Split("=").ToArray();

                Person person = new Person(currentPerson[0], double.Parse(currentPerson[1]));

                this.persons.Add(person);

            }

        }

        public void ValidateProductInput()
        {
            var productInput = Console.ReadLine().Split( ";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var item in productInput)
            {
                var currentProduct = item.Split("=").ToArray();

                Product product = new Product(currentProduct[0], double.Parse(currentProduct[1]));

                this.products.Add(product);

            }

        }

        public void CanBuy(string namePeople,string nameProduct)
        {
            var currentPeople = this.persons.FirstOrDefault(x => x.Name == namePeople);
            var currentProduct = this.products.FirstOrDefault(x => x.Name == nameProduct);

            if (currentPeople==null||currentProduct==null)
            {
                return;

            }


            currentPeople.CanAfford(currentProduct);

            



        }
       





    }
}
