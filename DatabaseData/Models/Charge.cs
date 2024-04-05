using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class Charge
    {
        public int ChargeId { get; }

        public int PersonId { get; }

        public int? EventId { get; }

        public decimal Amount { get; }

        public string Reason { get; }

        public DateTime Date { get; }

        public Charge(int chargeId, int personId, int? eventId, decimal amount, string reason, DateTime date)
        {
            ChargeId = chargeId;
            PersonId = personId;
            EventId = eventId;
            Amount = amount;
            Reason = reason;
            Date = date;
        }
    }
}
