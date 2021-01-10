using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IRobot> robots;

        public Procedure()
        {
            this.robots = new List<IRobot>();
        }

        public abstract void DoService(IRobot robot, int procedureTime);
       

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            foreach (IRobot robot in this.robots)
            {
                sb.AppendLine(robot.ToString());

            }

            //TODO:IF NOT GIVE MAX POINTS CHANGE IT TO TRIM()
            return sb.ToString().TrimEnd();
            
        }
    }
}
