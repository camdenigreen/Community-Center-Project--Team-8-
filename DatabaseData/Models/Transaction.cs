using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
   public  class Transaction
    {
        public int TransactionId { get; }

        public decimal Amount { get; }


        public string Type { get; }

        public DateTime Date { get; }

        public string Reason { get; }


        public Transaction(int id,decimal amount, string type, DateTime date,string reason)
        {
            TransactionId = id;
            Amount = amount;
            Type = type;
            Date = date;
            Reason = reason;
        }

    }
}
