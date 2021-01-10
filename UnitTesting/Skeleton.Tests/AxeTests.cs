using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe brokenAxe;
    private Axe normalAxE;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        normalAxE = new Axe(10, 10);
        brokenAxe = new Axe(10,0);
        dummy = new Dummy(10, 10);

    }
    [Test]
    public void AxeLoosesDurabilityAfterEveryAttack()
    {
        //Arrange
       
        
        //Dummy dummy = new Dummy(10, 10);

        //Act
        normalAxE.Attack(dummy);

        //Assert
        int expectedOutput = 9;
        int result = normalAxE.DurabilityPoints;

        Assert.That(result, Is.EqualTo(expectedOutput)
            ,"Axe neeed to loose durability after attack");
    }

    [Test]
    public void AxeCanNotAttackWithBrokenWeapon()
    {
        //Arrange

        //Axe axe = new Axe(0, 0);
        //Dummy dummy = new Dummy(10, 10);

       

        //Act-Assert
        Assert.Throws<InvalidOperationException>(()=>brokenAxe.Attack(dummy),"Axe is broken.");


    }
}