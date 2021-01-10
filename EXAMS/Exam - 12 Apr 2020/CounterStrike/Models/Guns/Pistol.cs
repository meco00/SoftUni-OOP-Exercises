using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount) : base(name, bulletsCount)
        {
        }

        public override int FireRate => 1;
    }
}
