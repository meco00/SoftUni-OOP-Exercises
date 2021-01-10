using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior = new Warrior("Goshko", 20, 100);
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
           

           
        }

        [Test]
        public void Ctor_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void Count_Should_Work_Correctly()
        {
            int expectedCount = 0;

            Assert.That(this.arena.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Enroll_ShouldWork_Correctly()
        {
            arena.Enroll(warrior);

           

            var result = arena.Warriors.FirstOrDefault(x=>x.Name==warrior.Name);


            Assert.That(this.arena.Warriors.Count, Is.EqualTo(1));
            Assert.That(this.arena.Warriors, Has.Member(warrior));


        }

        [Test]
        public void Enroll_Should_ThrowExceptionWhenTRYtoEnrollSameWarrior()
        {
           
            arena.Enroll(warrior);

            

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Goshko",100,120)));


            
        }


        [Test]
        public void Fight_ShouldThrowException_IfOneOrBothWarriorsAreNotInvolvedInArena()
        {
            arena.Enroll(warrior);



            Assert.Throws<InvalidOperationException>(() => arena.Fight("BayGanyo", "Bobi"));


            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior.Name, "Djoni"));


            Assert.Throws<InvalidOperationException>(() => arena.Fight("Gunco", warrior.Name));
              



        }

        [Test]
        public void Fight_Should_Work_Correctly()
        {


            Warrior warrior2 = new Warrior("Bobi", 30, 110);

            var warriorOriginalHP = warrior.HP;
            var warriorTwoOriginalHP = warrior2.HP;

            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            arena.Fight(warrior.Name, warrior2.Name);

            Assert.AreEqual(warrior.HP, warriorOriginalHP-warrior2.Damage);
            Assert.AreEqual(warrior2.HP, warriorTwoOriginalHP-warrior.Damage);



        }
    }
}
