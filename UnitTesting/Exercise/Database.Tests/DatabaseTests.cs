using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Constructor_Should_Work()
        {
            int[] array = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(array);
            


            Assert.AreEqual(database.Count, 16);


        }

        [Test]
        public void DatabaseShouldThrowInvalidOperationExceptionWhenCountIsBiggerThan16()
        {
            int[] array = Enumerable.Range(1, 15).ToArray();
            Database.Database database = new Database.Database(array);


            database.Add(1);


            Assert.That(database.Count, Is.EqualTo(16));
            Assert.Throws<InvalidOperationException>(()=>database.Add(1));
        }

        [Test]
        public void DatabaseShouldRemoveOnlyTheLastElement()
        {
            int[] array = Enumerable.Range(1, 15).ToArray();
            Database.Database database = new Database.Database(array);


            database.Remove();

            Assert.That(database.Count, Is.EqualTo(14));


        }

        [Test]
        public void DatabaseThrowsExceptionWhenRemovesFromEmpty()
        {

            Database.Database database = new Database.Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethodShouldWork()
        {
            int[] array = Enumerable.Range(1, 15).ToArray();
            Database.Database database = new Database.Database(array);

            int[] fetchArray = database.Fetch();

            CollectionAssert.AreEqual(array, fetchArray);


        }




    }
}