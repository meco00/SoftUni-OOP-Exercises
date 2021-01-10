using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Models
{
    public class Work : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (procedureTime <= robot.ProcedureTime)
            {

                robot.Happiness += 12;
                robot.Energy -= 6;

                robot.ProcedureTime -= procedureTime;
                this.robots.Add(robot);

            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
        }
    }
}
