using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {

        public Transaction(int id,string from,string to,double amount,TransactionStatus status)
        {
            this.Id = id;
            this.From = from;
            this.To = to;
            this.Amount = amount;
            this.Status = status;

        }

        public int Id { get; }
        public TransactionStatus Status { get; set; }
        public string From { get; }
        public string To { get; }
        public double Amount { get; }


    }

}

