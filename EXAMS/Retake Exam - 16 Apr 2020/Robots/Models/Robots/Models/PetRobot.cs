﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots.Models
{
    public class PetRobot : Robot
    {
        public PetRobot(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }
    }
}
