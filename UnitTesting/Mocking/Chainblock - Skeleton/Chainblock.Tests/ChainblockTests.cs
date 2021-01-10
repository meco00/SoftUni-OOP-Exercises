using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;


namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests

    {
        private Transaction transaction;
        private MyChainBlock chainblock;

        [SetUp]
          public void Initialize()
        {
            chainblock = new MyChainBlock();

            transaction = new Transaction(1, "Bont", "Djont", 15.55, TransactionStatus.Unauthorized);
            


        }

        [Test]
        [Category("Add method")]
        public void AddMethod_ShouldWorkCorrect()
        {
            chainblock.Add(transaction);

            Assert.Pass();

        }

        [Test]
        [Category("Add method")]
        public void AddMethod_ShouldThrowArgumenExceptionIfTryToAddExistingTransaction()
        {
            chainblock.Add(transaction);

            Assert.Throws<ArgumentException>(()=> chainblock.Add(transaction));

        }



        [Test]
        [Category("Contains method")]
       public void Contains_Id_Should_WorkCorrectlyWithValidParam()
        {

            chainblock.Add(transaction);

            Assert.That(() => chainblock.Contains(transaction.Id), Is.EqualTo(true));

        }

        [Test]
        [Category("Contains method")]
        public void Contains_Transaction_Should_WorkCorrectlyWithValidParam()
        {
            //TODO:
            chainblock.Add(transaction);

            Assert.That(() => chainblock.Contains(this.transaction), Is.EqualTo(true));

        }

        [Test]
        [Category("Count method")]
        public void Count_Should_Return_ValidParams()
        {
            Assert.That(this.chainblock.Count, Is.EqualTo(0));


            chainblock.Add(transaction);

            Assert.That(this.chainblock.Count,Is.EqualTo(1));

        }


        [Test]
        [Category("ChangeTransactionStatus method")]
        public void ChangeTransactionStatus_Method_ShouldThrow_ArgumentExceptionWhenEnterInvalidId()
        {

            

            Assert.Throws<ArgumentException>(()=>chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed));

        }

        [Test]
        [Category("ChangeTransactionStatus method")]
        public void ChangeTransactionStatus_Method_ShouldThrow_ArgumentExceptionWhenEnteredSameStatus()
        {

            chainblock.Add(transaction);

            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(1, TransactionStatus.Unauthorized));

        }

        [Test]
        [Category("ChangeTransactionStatus method")]
        public void ChangeTransactionStatus_Method_ShouldWorkCorrectly_WhenEnteredValidParams()
        {

            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);

            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.Failed));

        }


        [Test]
        [Category("RemoveTransactionById method")]
        public void RemoveTransactionById_ShouldThrowInvalidOperationExceptionWhenEnterInvalidId()
        {


            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(2));
            

        }

        [Test]
        [Category("RemoveTransactionById method")]
        public void RemoveTransactionById_ShouldRemoveTransactionSuccesfullyWhenEnterValidParams()
        {
            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(transaction.Id);

            Assert.That(chainblock.Count, Is.EqualTo(0));
            Assert.That(chainblock.Contains(transaction), Is.EqualTo(false));


        }


        [Test]
        [Category("GetById method")]
        public void GetById_ShouldThowException_When_Enter_InvalidId()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(2));

        }

        [Test]
        [Category("GetById method")]
        public void GetById_ShouldWork_Correctly()
        {
            chainblock.Add(transaction);

            var currentTransaction = chainblock.GetById(transaction.Id);

            Assert.AreEqual(transaction, currentTransaction);



           
        }


        [Test]
        [Category("GetByTransactionStatus method ")]
        
        public void GetByTransactionStatus_ShouldThrowExceptionWithEmptyCollection()
        {
            //chainblock.Add(transaction);

            

            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));




        }

        [Test]
        [Category("GetByTransactionStatus method ")]

        public void GetByTransactionStatus_ShouldWorkCorrectly()
        {
            chainblock.Add(transaction);

            chainblock.Add(new Transaction(2,"Djoni","bobi",25.55,TransactionStatus.Unauthorized));

            chainblock.Add(new Transaction(3,"Djoni","bobi",35.55,TransactionStatus.Unauthorized));

            chainblock.Add(new Transaction(4,"Djoni","bobi",45.55,TransactionStatus.Unauthorized));

            chainblock.Add(new Transaction(5,"Djoni","bobi",45.55,TransactionStatus.Failed));



            List<ITransaction> collection = this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized).ToList();

            Assert.AreEqual(collection.Count, 4);
            




           




        }



        [Test]
        [Category("GetAllSendersWithTransactionStatus method ")]
        public void GetAllSendersWithTransactionStatus_ShouldThrowExceptionWhenNull()
        {

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull));









        }


        [Test]
        [Category("GetAllSendersWithTransactionStatus method ")]
        public void GetAllSendersWithTransactionStatus_ShouldWorkCorrectly()
        {

            chainblock.Add(transaction);

            chainblock.Add(new Transaction(2, "Djoni", "bobi", 25.55, TransactionStatus.Unauthorized));

            chainblock.Add(new Transaction(3, "Djoni", "bobi", 35.55, TransactionStatus.Unauthorized));

            chainblock.Add(new Transaction(4, "Djoni", "bobi", 45.55, TransactionStatus.Unauthorized));

            chainblock.Add(new Transaction(5, "Djoni", "bobi", 45.55, TransactionStatus.Failed));



            List<string> collection = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized).ToList();

            Assert.AreEqual(collection.Count, 4);
            Assert.AreEqual(collection[0], transaction.To);
            Assert.AreEqual(collection[1], "bobi");
            Assert.AreEqual(collection[2], "bobi");
            Assert.AreEqual(collection[3], "bobi");










        }




    }
}
