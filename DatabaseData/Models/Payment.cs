using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class Payment
    {
        public int PaymentId { get; }

        public int PersonId { get; }

        public decimal Amount { get; }

        public string Reason { get; }

        public DateTime Date { get; }

        public Payment(int paymentId, int personId, decimal amount, string reason, DateTime date)
        {
            PaymentId = paymentId;
            PersonId = personId;
            Amount = amount;
            Reason = reason;
            Date = date;
        }
    }
}
