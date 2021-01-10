using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private readonly Dictionary<string, IRobot> robots;

        private int Count;

        public Garage()
        {
            this.Count = 10;
            this.robots = new Dictionary<string, IRobot>();

        }

        //TODO:IF FAIL CHECK HERE FIRST
        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            

            if (this.robots.Count == this.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);

            }

            if (this.robots.Any(x=>x.Key==robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));

            }


            this.robots.Add(robot.Name, robot);



            
        }

        public void Sell(string robotName, string ownerName)
        {
            var currentRobot = this.robots.FirstOrDefault(x => x.Key == robotName).Value;

            if (currentRobot is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            }

            currentRobot.Owner = ownerName;
            currentRobot.IsBought = true;
            this.robots.Remove(robotName);

           
           
        }
    }
}
