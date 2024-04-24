using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Center_Project__Team_8_
{
    public class PaymentEventArgs
    {
        public string Reason;
        public decimal Amount;
        public DateTime Time;
        public PaymentEventArgs(string reason,decimal amount,DateTime time)
        {
            Reason = reason;
            Amount = amount;
            Time = time;

        }
    }
}
