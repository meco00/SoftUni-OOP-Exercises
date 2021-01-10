using NUnit.Framework;
using System;
using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        
        private const string STRING_EMPTY = "";
        private const string VALID_NAME = "Pesho";
        private const int DMG_INFO = 15;
        private const int HP_INFO = 10;

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Constructor_Should_ThrowException_WhenNameIsEmptyAndNull()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(STRING_EMPTY, DMG_INFO, HP_INFO));
            Assert.Throws<ArgumentException>(() => new Warrior(null, DMG_INFO, HP_INFO));
        }

        [Test]
        public void Constructor_Should_ThrowException_WhenDmgIsLessOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(STRING_EMPTY,0 , HP_INFO));
            Assert.Throws<ArgumentException>(() => new Warrior(STRING_EMPTY,-1 , HP_INFO));
        }

        [Test]
        public void Constructor_Should_ThrowException_WhenDmgIsLessThanZero()
        {
            
            Assert.Throws<ArgumentException>(() => new Warrior(STRING_EMPTY, DMG_INFO, -1));
        }

        [Test]
        public void Constructor_Should_WorkWithValidParams()
        {
            this.warrior= new Warrior(VALID_NAME, DMG_INFO, HP_INFO);

            Assert.AreEqual(warrior.Name, VALID_NAME);
            Assert.AreEqual(warrior.Damage, DMG_INFO);
            Assert.AreEqual(warrior.HP, HP_INFO);
           
        }

        [Test]
        public void AttackMethodShouldThrowExceptionWith_HP_IsLessThan30_AndAttackerDMGisGreaterThanThisWarriorsHP()
        {
            this.warrior = new Warrior(VALID_NAME, DMG_INFO, HP_INFO);
            Warrior enemyWarrior = new Warrior("Bobi", 200, 10);
             Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(enemyWarrior));


            this.warrior = new Warrior(VALID_NAME, DMG_INFO, 100);

            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(enemyWarrior),
                "Enemy HP must be greater than 30 in order to attack him!");


            enemyWarrior = new Warrior("Djoni", 200, 50);

            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(enemyWarrior), 
                "You are trying to attack too strong enemy");

        }

        [Test]
        [TestCase(50,100,20,40)]
        public void AttackMethod_Should_WorkCorrectlyWithValidParams
            (
            int warriorDmg,
            int warriorHP,
            int enemyDmg,
            int enemyHP
            )
        {
            this.warrior = new Warrior(VALID_NAME, warriorDmg, warriorHP);

            Warrior enemyWarrior = new Warrior("Bobi", enemyDmg, enemyHP);

            this.warrior.Attack(enemyWarrior);

            Assert.AreEqual(enemyWarrior.HP, 0);
            Assert.AreEqual(this.warrior.HP, warriorHP-enemyDmg);

            enemyWarrior = new Warrior(VALID_NAME, enemyDmg, enemyDmg+enemyHP);

            this.warrior.Attack(enemyWarrior);

            Assert.AreEqual(enemyWarrior.HP, warriorDmg-enemyHP);
            Assert.AreEqual(this.warrior.HP, enemyDmg + enemyHP);


        }
    }
}