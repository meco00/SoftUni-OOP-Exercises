using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Models
{
    public class Chip : Procedure
    {

        public override void DoService(IRobot robot, int procedureTime)
        {
           
            if (procedureTime<=robot.ProcedureTime)
            {
                if (robot.IsChipped)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));
                }

                robot.Happiness -= 5;
                robot.IsChipped = true;
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
