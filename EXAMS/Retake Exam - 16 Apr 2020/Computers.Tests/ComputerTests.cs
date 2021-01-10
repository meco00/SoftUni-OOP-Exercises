namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerNeedToThrowExceptionWIhtINVname()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(null));
            Assert.Throws<ArgumentNullException>(() => new Computer(""));
      
        }

        [Test]
        public void ComputerNeedToPass()
        {
            var comp = new Computer("zaza");

            Assert.Pass();

            Assert.AreEqual(comp.Parts.Count, 0);

        }

        [Test]
        public void ComputerAddPartNedToThorwException()
        {
            var comp = new Computer("zaza");

           

            Assert.Throws<InvalidOperationException>(() => comp.AddPart(null));


        }
        [Test]
        public void ComputerAddPartNedToWork()
        {

            var comp = new Computer("zaza");

            var part = new Part("bobi", 15);

            comp.AddPart(part);

            Assert.AreEqual(comp.Parts.Count, 1);

            


        }
        [Test]
        public void ComputerTotalPriceAndGetMethodAndRemoveMethodShouldWork()
        {

            var comp = new Computer("zaza");


            var part = new Part("bobi", 15);
            var part1 = new Part("bobi1", 15);



            comp.AddPart(part);
            comp.AddPart(part1);




            Assert.AreEqual(comp.TotalPrice ,30);


            Assert.AreEqual(comp.RemovePart(part), true);
            Assert.AreEqual(comp.Parts.Count, 1);


            Assert.AreEqual(comp.GetPart(part1.Name), part1);





        }



    }
}