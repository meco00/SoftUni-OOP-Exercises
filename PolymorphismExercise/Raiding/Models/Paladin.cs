using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
          
        }

        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";

        }
    }
}
