using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Chainblock.Models
{
    public class MyChainBlock : IChainblock
    {
        private IDictionary<int, ITransaction> _transactions;

        public MyChainBlock()
        {
            _transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => this._transactions.Count;

        public void Add(ITransaction tx)
        {
            bool contains = this.Contains(tx.Id);

            if (contains)
            {
                throw new ArgumentException();

            }

            this._transactions.Add(tx.Id,tx);


            
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            bool isValidId = this.Contains(id);

            if (!isValidId)
            {
                throw new ArgumentException();

            }
            if (this._transactions[id].Status==newStatus)
            {
                throw new ArgumentException();

            }

            this._transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            

            return this.Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            if (id<=0)
            {
                 throw new InvalidOperationException();

            }
            if (!this._transactions.ContainsKey(id))
            {
                return false;
            }
            return true;
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException();
            }

            this._transactions.Remove(id);
        }


        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException();

            }

           

            return this._transactions.First(x => x.Key == id).Value;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!(this._transactions.Any(x=>x.Value.Status==status)))
            {
                throw new InvalidOperationException();
            }

            Dictionary<int, ITransaction> dictionary =
                this._transactions.Where(x => x.Value.Status == status)
                .OrderByDescending(x => x.Value.Amount)
                .ToDictionary(x => x.Key, x => x.Value);




            return dictionary.Values.ToList();
        }


        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!(this._transactions.Any(x => x.Value.Status == status)))
            {
                throw new InvalidOperationException();
            }
           



            return this._transactions.Where(x => x.Value.Status == status).Select(x => x.Value.To).ToList();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
