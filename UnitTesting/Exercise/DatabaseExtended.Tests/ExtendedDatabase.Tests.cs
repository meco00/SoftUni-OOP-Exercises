using NUnit.Framework;
using ExtendedDatabase;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person person;
        private  Person[] persons = new Person[]
        {
            new Person(1,"Ivan"),
            new Person(2,"Stamat")
        };

        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {

            person = new Person(1, "Bobi");
            Person person2 = new Person(2, "Bobi2");
            Person person3 = new Person(3, "Bobi3");
            Person person4 = new Person(4, "Bobi4");
            Person person5 = new Person(5, "Bobi5");
            Person person6 = new Person(6, "Bobi6");
            Person person7 = new Person(7, "Bobi7");
            Person person8 = new Person(8, "Bobi8");
            Person person9 = new Person(9, "Bobi9");
            Person person10 = new Person(10, "Bobi10");
            Person person11 = new Person(11, "Bobi11");
            Person person12 = new Person(12, "Bobi12");
            Person person13 = new Person(13, "Bobi13");
            Person person14 = new Person(14, "Bobi14");
            Person person15 = new Person(15, "Bobi15");
           

            persons = new Person[]
            {
                 person,
                 person2,
                 person3,
                 person4,
                 person5,
                 person6,
                 person7,
                 person8,
                 person9,
                 person10,
                 person11,
                 person12,
                 person13,
                 person14,
                 person15,
               




            };

            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons);

        }

        [Test]
        public void DatabaseConstructorShouldWorkAndThrowsExceptionWhenCountIsAbove16()
        {
            


            int expectedCount = 15;

            int result = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, result);



            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(new Person[17]));


        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenCountIsAbove16()
        {
           

            Person person17 = new Person(17, "Bobi17");

           

            extendedDatabase.Add(new Person(16, "Bobi16"));

            

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(person17));

        }


        [Test]
        public void DatabaseShouldThrowExceptionWhenAddPersonWithSameName()
        {
            

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16, "Bobi")));

        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenAddPersonWithSameId()
        {
           

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(1, "Bobi20")));
        }

        [Test]
        public void DatabaseShouldAddPersonWhenThereIsFreePlace()
        {
            
            extendedDatabase.Add(new Person(16, "Bobi16"));

            Assert.AreEqual(16, extendedDatabase.Count);
        }

        [Test]
        public void DatabaseShouldThrowExceptionWhenRemoveEMPTY()
        {
           this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        public void DatabaseShouldRemovePersonIfNotEmpty()
        {
           
            extendedDatabase.Remove();

            int expectedCount = 14;
            int result = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, result);


        }

        [Test]
        public void Database_Should_Correctly_Remove()
        {
            int expectedCount = 14;
            extendedDatabase.Remove();

            int result = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, result);
        }

        [Test]
        public void DatabaseShouldThrowExcpFindBy()
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(""));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername("Bont"));

            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(-1));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(100));





        }

        [Test]
        public void FindByShouldCorrectlyWork()
        {
            Person person = new Person(1, "Bobi");
            string username = "Bobi";

            int Id = 1;


            

            Assert.That(extendedDatabase.FindByUsername(username).UserName,Is.EqualTo(person.UserName));

            Assert.That(extendedDatabase.FindById(Id).Id, Is.EqualTo(person.Id));
        }

      



    }
}