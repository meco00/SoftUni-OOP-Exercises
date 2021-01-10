using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    [SetUp]
    public void Initialize()
    {
        dummy = new Dummy(10, 10);
    }

    [SetUp]
    public void SecondInitialize()
    {
        dummy = new Dummy(0, 10);
    }

    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        this.Initialize();
        ////Arrange
        //Dummy dummy = new Dummy(10, 10);

        //Act
        dummy.TakeAttack(1);

        //Assert
        int expectedHealth = 9;
        int result = dummy.Health;

        Assert.That(expectedHealth, Is.EqualTo(result));




    }
    [Test]
    public void AliveDummyCanNotGiveExp()
    {
        this.Initialize();
        //Dummy dummy = new Dummy(1, 10);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");


    }

    [Test]   
    public void DeadDummyThrowsExceptionWhenAttacked()
    {
        this.SecondInitialize();

        
        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1), "Dummy is dead.");

    }

    [Test]  
    public void DeadDummyCanGiveExp()
    {

        this.SecondInitialize();
        //Act
        int expectedOutput = 10;
        int result = dummy.GiveExperience();

        //Assert
        Assert.That(expectedOutput, Is.EqualTo(result));
    }



}

