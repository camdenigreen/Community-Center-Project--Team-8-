using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
   public  class Transaction
    {
        

        public decimal Amount { get; }

        public string Type { get; }

        public DateTime Date { get; }

        public string Reason { get; }


        public Transaction(decimal amount, string type, DateTime date,string reason)
        {

            Amount = amount;
            Type = type;
            Date = date;
            Reason = reason;
        }

    }
}
