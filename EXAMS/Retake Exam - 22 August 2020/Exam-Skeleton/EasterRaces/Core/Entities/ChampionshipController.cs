using EasterRaces.Core.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races;
using System.Reflection;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController

    {
        private CarRepository carRepository = new CarRepository();
        private DriverRepository driverRepository = new DriverRepository();
        private RaceRepository raceRepository = new RaceRepository();


        public string CreateCar(string type, string model, int horsePower)
        {

            if (carRepository.GetAll().Any(x=>x.Model==model))
            {
                throw new ArgumentException($"Car { model } is already created.");

            }

            //With Reflection :

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type typeOfCar = assembly.GetTypes().FirstOrDefault(x=>x.Name==$"{type}Car");

            object[] ctorParams = new object[] { model, horsePower };

            ICar car = (ICar)Activator.CreateInstance(typeOfCar, ctorParams);


            //Normal :

            //if (type=="Muscle")
            //{
            //    car = new MuscleCar(model, horsePower);

            //}
            //else if (type== "Sports")
            //{
            //    car = new SportsCar(model, horsePower);

            //}


            this.carRepository.Add(car);

            return $"{car.GetType().Name} {model} is created.";


            
           
        }

        public string CreateDriver(string driverName)
        {
            if (driverRepository.GetAll().Any(x=>x.Name==driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));

            }

            driverRepository.Add(new Driver(driverName));

            return $"Driver {driverName} is created.";
            
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var currentDriver = this.driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);
            if (currentDriver is null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");

            }

            var currentCar = this.carRepository.GetAll().FirstOrDefault(x => x.Model == carModel);
            if (currentCar is null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found..");
            }

            currentDriver.AddCar(currentCar);




            return $"Driver {currentDriver.Name} received car {currentCar.Model}.";
        }


        public string AddDriverToRace(string raceName, string driverName)
        {

            var currentRace = this.raceRepository.GetAll().FirstOrDefault(x => x.Name == raceName);

            //IF HAVE BUGS TRY TO CHANGE RACE ASK WITH DRIVER ASK

            if (currentRace is null)
            {
                throw new InvalidOperationException($"Race { raceName } could not be found.");
            }

            var currentDriver= this.driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);

            if (currentDriver is null)
            {
                throw new InvalidOperationException($"Driver { driverName } could not be found.");

            }

            currentRace.AddDriver(currentDriver);

            return $"Driver {driverName} added in {raceName} race.";



            

            
        }



        public string CreateRace(string name, int laps)
        {
            if ((raceRepository.GetAll().Any(x=>x.Name==name)))
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }


            var currentRace = new Race(name, laps);
            this.raceRepository.Add(currentRace);


            return $"Race {name} is created.";

            
        }

        public string StartRace(string raceName)
        {
            var currentRace = this.raceRepository.GetAll().FirstOrDefault(x => x.Name == raceName);
            if (currentRace is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (currentRace.Drivers.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            foreach (var driver in currentRace.Drivers)
            {
                driver.Car.CalculateRacePoints(currentRace.Laps);

            }

            var rankingList = currentRace.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(currentRace.Laps)).Take(3).ToList();

            StringBuilder sb = new StringBuilder();

            rankingList[0].WinRace();
            sb.AppendLine($"Driver {rankingList[0].Name} wins {currentRace.Name} race.");
            sb.AppendLine($"Driver {rankingList[1].Name} is second in {currentRace.Name} race.");
            sb.AppendLine($"Driver {rankingList[2].Name} is third in {currentRace.Name} race.");


            this.raceRepository.Remove(currentRace);

            return sb.ToString().Trim();



            
            
        }
    }
}
