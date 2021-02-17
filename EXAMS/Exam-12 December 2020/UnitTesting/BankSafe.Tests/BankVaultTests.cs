using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ItemConstructorShouldWork()
        {
            string owner = "Pesho";
            string Id = "Joro";

            var item = new Item(owner, Id);

            Assert.AreEqual(item.Owner, owner);
            Assert.AreEqual(item.ItemId, Id);


        }

        [Test]
        public void BankConstrtShldWork()
        {
            BankVault bank = new BankVault();

            Assert.Pass();


        }

        [Test]
        public void BankDictionaryCheckIfWorks()
        {
            BankVault bank = new BankVault();

             var vaultCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            var vaultCells2 = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C8", null},
            };


            Assert.AreEqual(bank.VaultCells.Count, 12);
            CollectionAssert.AreEqual(vaultCells,bank.VaultCells);

            CollectionAssert.AreNotEqual(vaultCells2,bank.VaultCells);


        }

      

        [Test]
        public void AddMethodShouldThrowExceptionWhenDoesNotContainsSuchAnElement()
        {
            BankVault bank = new BankVault();

            Assert.Throws<ArgumentException>(()=>bank.AddItem("A11",null));


        }

        public void AddMethodShouldThrowExceptionIfCellIsTaken()
        {
            BankVault bank = new BankVault();

            string owner = "Pesho";
            string Id = "Joro";

            var item = new Item(owner, Id);

            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", item));


        }

        [Test]
        public void AddMethodShouldThrowInvalidExceptionIfExistSuchItem()
        {
            BankVault bank = new BankVault();

            string owner = "Pesho";
            string Id = "Joro";

            var item = new Item(owner, Id);

            bank.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A2", item));


        }

        [Test]
        public void AddMethodShouldWorkWithValidData()
        {
            BankVault bank = new BankVault();

            string owner = "Pesho";
            string Id = "Joro";

            var item = new Item(owner, Id);

            string expectedResult= $"Item:{item.ItemId} saved successfully!";

            string actualResult= bank.AddItem("A1", item);

            Assert.AreEqual(expectedResult, actualResult);


        }

  

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenEnterInvalidCell()
        {
            BankVault bank = new BankVault();

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A11", null));


        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenEnterCellThatDoesNotExist()
        {
            BankVault bank = new BankVault();

            string owner = "Pesho";
            string Id = "Joro";

            var item = new Item(owner, Id);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A1", item));


        }

        [Test]
        public void RemoveMethodShouldWorkAsExpected()
        {
            BankVault bank = new BankVault();

            string owner = "Pesho";
            string Id = "Joro";

            var item = new Item(owner, Id);
            bank.AddItem("A1", item);


            string expectedResult= $"Remove item:{item.ItemId} successfully!";


            string result = bank.RemoveItem("A1", item);

            Assert.AreEqual(expectedResult, result);

            


        }




    }
}