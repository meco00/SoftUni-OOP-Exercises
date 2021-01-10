using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Models
{
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (procedureTime <= robot.ProcedureTime)
            {

               
                robot.Energy -= 8;

                robot.ProcedureTime -= procedureTime;

                //TODO:IF NOT GIVE MAX POINT SUBTRACT ENERGY AGAIN
                robot.IsChecked = true;
                if (!(this.robots.Contains(robot)))
                {
                    this.robots.Add(robot);
                }

            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
        }
    }
}
