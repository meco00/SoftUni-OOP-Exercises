using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise.Models
{
   public interface IVehicle
    {
        void Drive(double amount,bool hasAirCondition);
        void Refuel(double fuel);
    }
}
