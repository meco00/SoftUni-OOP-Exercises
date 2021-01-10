using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {

        private Car car;

        private const string EMPTY_STRING = "";



        private const string MAKE_INFO = "BG";

        private const string MODEL_INFO = "VW";

        private const double COMMON_FUELINFO = 20.00;
        private const double COMMON_CONSUMPTION = 5.00;

        private const double NEGATIVE_FUELINFO = -1;



        [SetUp]
        public void Setup()
        {
             car = new Car(MAKE_INFO, MODEL_INFO, COMMON_CONSUMPTION, COMMON_FUELINFO);
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenMakeORtheModelIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Car(EMPTY_STRING, MODEL_INFO, COMMON_FUELINFO, COMMON_FUELINFO));

            Assert.Throws<ArgumentException>(() => new Car( MODEL_INFO, EMPTY_STRING,COMMON_FUELINFO, COMMON_FUELINFO));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenFuelInfoIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car(MODEL_INFO, MODEL_INFO, NEGATIVE_FUELINFO, COMMON_FUELINFO));

            Assert.Throws<ArgumentException>(() => new Car(MODEL_INFO, MODEL_INFO, COMMON_FUELINFO, NEGATIVE_FUELINFO));
        }

        [Test]
        public void Constructor_Should_Work_Correctly()
        {
           

            Assert.AreEqual(car.Make, MAKE_INFO);
            Assert.AreEqual(car.Model, MODEL_INFO);
            Assert.AreEqual(car.FuelConsumption, COMMON_CONSUMPTION);
            Assert.AreEqual(car.FuelCapacity, COMMON_FUELINFO);

        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Refuel_ShouldThrowExceptionWhenInputIsNegativeOrZero(int fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));

        }

        [Test]
        [TestCase(25)]
        [TestCase(20)]
        public void Refuel_Should_Correctly_Work(double fuel)
        {
            car.Refuel(fuel);

            Assert.That(car.FuelAmount, Is.EqualTo(COMMON_FUELINFO));

        }

        [Test]
        public void Drive_Should_Throw_ExceptionWhenDontHaveEnoughFuel()
        {
            car.Refuel(COMMON_FUELINFO);

            

            Assert.Throws<InvalidOperationException>(() => car.Drive(500));


        }

        [Test]
        public void Drive_Should_Work_Correctly()
        {
            car.Refuel(COMMON_FUELINFO);

            double driving= ((50.0 / 100.0) * car.FuelConsumption);
            double expectedResult = car.FuelAmount - driving;

            car.Drive(50);
            double result = car.FuelAmount;

            Assert.AreEqual(Math.Round(expectedResult,2), result);



        }


        





    }
}