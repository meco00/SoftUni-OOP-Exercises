using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Procedures.Models;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Robots.Models;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
       
        private IProcedure chip = new Chip();
        private IProcedure charge=new Charge();
        private IProcedure polish = new Polish();
        private IProcedure rest=new Rest();
        private IProcedure tech = new TechCheck();
        private IProcedure work=new Work();



        public Controller()
        {
            garage = new Garage();
            
        }

        public string Charge(string robotName, int procedureTime)
        {
            var currentRobot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            if (currentRobot is null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            

            charge.DoService(currentRobot, procedureTime);

            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            var currentRobot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            if (currentRobot is null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            

            chip.DoService(currentRobot, procedureTime);

            return $"{robotName} had chip procedure";


        }


        public string History(string procedureType)
        {
            string output = string.Empty;
            if (procedureType=="Charge")
            {
                output = charge.History();

            }
            else if (procedureType == "Chip")
            {
                output = chip.History();
            }
            else if (procedureType == "Polish")
            {
                output = polish.History();
            }
           else  if (procedureType == "Rest")
            {
                output = rest.History();
            }
            else if (procedureType == "TechCheck")
            {
                output = tech.History();
            }
           else  if (procedureType == "Work")
            {
                output = work.History();
            }

            return output;
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Type type = assembly.GetTypes().FirstOrDefault(x => x.Name == robotType);

            //if (type is null)
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));

            //}
            //object[] obj = new object[] { name, energy, happiness, procedureTime };
            //IRobot robot = (IRobot)Activator.CreateInstance(type, obj);

            IRobot robot;
            if (robotType=="HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));

            }

            garage.Manufacture(robot);


            return $"Robot {name} registered successfully";





        }

        public string Polish(string robotName, int procedureTime)
        {
            var currentRobot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            if (currentRobot is null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            

            polish.DoService(currentRobot, procedureTime);

            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            var currentRobot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            if (currentRobot is null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            

            rest.DoService(currentRobot, procedureTime);

            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            var currentRobot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;



            garage.Sell(robotName, ownerName);


            if (currentRobot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }

            return $"{ownerName} bought robot without chip";

           


        }

        public string TechCheck(string robotName, int procedureTime)
        {
            var currentRobot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            if (currentRobot is null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            

            tech.DoService(currentRobot, procedureTime);

            return $"{robotName} had tech check procedure";

        }

        public string Work(string robotName, int procedureTime)
        {
            var currentRobot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            if (currentRobot is null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
           

            work.DoService(currentRobot, procedureTime);

            return $"{robotName} was working for {procedureTime} hours";
        }
    }
}
