using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero:IAbility
    {
        public string Name { get; }
       public abstract int Power { get; }

        public BaseHero(string name)
        {
            this.Name = name;
           

        }







        public abstract string CastAbility();
    }
}
