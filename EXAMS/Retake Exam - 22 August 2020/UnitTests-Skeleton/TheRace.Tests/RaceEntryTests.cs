using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitDriverNeedToTrExcp()
        {
            Assert.Throws<ArgumentNullException>(()=> new UnitDriver(null,new UnitCar("test",1,1)));
        }

        [Test]
        public void UnitDriverNeedToWorkCorrectly()
        {
            var driver = new UnitDriver("Test", new UnitCar("bobi", 1, 1));

            Assert.Pass();
        }

        [Test]
        public void RaceConstrNeedTowork()
        {
          

            var race = new RaceEntry();

            Assert.AreEqual(race.Counter, 0);
            
        }

        [Test]
        public void RaceNeedToThrExcpWhenAddNullDriverAndWork()
        {


            var race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));




            var driver = new UnitDriver("Test", new UnitCar("bobi", 1, 1));

             string bobo= race.AddDriver(driver);
            Assert.AreEqual(race.Counter, 1);
            Assert.AreEqual(bobo, $"Driver {driver.Name} added in race.");

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));









        }

        [Test]
        public void LastMethod()
        {

            var driver = new UnitDriver("Test", new UnitCar("bobi", 1, 1));
            var driver2 = new UnitDriver("Test2", new UnitCar("bobi", 1, 1));
            var driver3 = new UnitDriver("Test3", new UnitCar("bobi", 1, 1));

            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(()=>race.CalculateAverageHorsePower());

            race.AddDriver(driver);
            race.AddDriver(driver2);
            race.AddDriver(driver3);

            var num = race.CalculateAverageHorsePower();

            Assert.AreEqual(num, 1);


            





        }
    }
}