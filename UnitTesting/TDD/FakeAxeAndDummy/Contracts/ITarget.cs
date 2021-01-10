using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy
{
    public interface ITarget
    {
        public int Health { get; }
        void TakeAttack(int attackPoints);
        int GiveExperience();
        bool IsDead();
    }
}
