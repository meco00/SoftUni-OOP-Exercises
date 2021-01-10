using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;


[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainExpWhenKillsTargetMock()
    {


        

       Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Mock<ITarget> fakeDummy = new Mock<ITarget>();

        fakeDummy.Setup(x => x.IsDead()).Returns(true);
        fakeDummy.Setup(x => x.GiveExperience()).Returns(20);

       
        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        hero.Attack(fakeDummy.Object);



        Assert.AreEqual(hero.Experience, fakeDummy.Object.GiveExperience());

    }

    [Test]
    public void HeroShouldGainExpWhenKillsTargetFakes()
    {
        var fakeWeapon = new FakeWeapon();
        var fakeTarget = new FakeTarget();



        Hero hero = new Hero("Pesho", fakeWeapon);

        hero.Attack(fakeTarget);

        Assert.AreEqual(hero.Experience, fakeTarget.GiveExperience());
    }
}