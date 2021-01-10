using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CnstrWork()
        {
            ComputerManager manager = new ComputerManager();

           

            Assert.AreEqual(manager.Computers.Count, 0);


        }

        [Test]
        public void ComputerConstructorShldWork()
        {
            Computer manager = new Computer("Djoni","Bobi",15);



            Assert.AreEqual(manager.Manufacturer, "Djoni");
            Assert.AreEqual(manager.Model, "Bobi");
            Assert.AreEqual(manager.Price, 15);


        }


        [Test]
        public void AddShldWork()
        {
            ComputerManager manager = new ComputerManager();

            Computer computer = new Computer("BG", "Lenovo", 15);

            manager.AddComputer(computer);

            Computer comp = (Computer)manager.Computers.ToList()[0];

            Assert.AreEqual(comp, computer);



            Assert.AreEqual(manager.Count, 1);

           Assert.AreEqual(manager.Computers.Count, 1);




        }


        [Test]
        public void AddShldThrException()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("BG", "Lenovo", 15);

            manager.AddComputer(computer);


            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));

            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(null));

        }
        [Test]
        public void RemoveCompShlWork()
        {
            ComputerManager manager = new ComputerManager();

            Computer computer = new Computer("BG", "Lenovo", 15);

            manager.AddComputer(computer);

            var comp = manager.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.AreEqual(manager.Computers.Count, 0);

            Assert.AreEqual(computer, comp);

           




           


        }
        [Test]
        public void RemoveCompShouldThrowException()
        {
            ComputerManager manager = new ComputerManager();

            Computer computer = new Computer("BG", "Lenovo", 15);

           

           
            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer("DJONI", null));
            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer(null,"DJONI"));

            Assert.Throws<ArgumentException>(() => manager.RemoveComputer("ZaZA", "bOBI"));

           









        }
        [Test]
        public void GetCompShldWork()
        {
            ComputerManager manager = new ComputerManager();

            Computer computer = new Computer("BG", "Lenovo", 15);




            manager.AddComputer(computer);

              var comp= manager.GetComputer(computer.Manufacturer, computer.Model);

            

           
            Assert.AreEqual(computer,comp);







        }
        [Test]
        public void GetCompShlothrExcp()
        {
            ComputerManager manager = new ComputerManager();
           

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null,"DJONI"));
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("DJONI",null));

            Assert.Throws<ArgumentException>(() => manager.GetComputer("ZaZA","bOBI"));


        }

        [Test]
        public void GetCmpManufacturet()
        {
            ComputerManager manager = new ComputerManager();

            Computer computer = new Computer("BG", "Lenovo", 15);
            Computer computer1 = new Computer("BG", "Asus", 15);
            Computer computer2 = new Computer("UK", "Asus", 15);

            List<Computer> list = new List<Computer>() { computer, computer1 };




            manager.AddComputer(computer);
            manager.AddComputer(computer1);


           

            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null));


            var result = manager.GetComputersByManufacturer("BG");

            CollectionAssert.Contains(result, computer);
            CollectionAssert.Contains(result, computer1);
            CollectionAssert.DoesNotContain(result, computer2);



            CollectionAssert.AreEqual(result, list);

            var nullCollection = manager.GetComputersByManufacturer("UK");

            Assert.AreEqual(nullCollection.Count, 0);







        }
    }
}