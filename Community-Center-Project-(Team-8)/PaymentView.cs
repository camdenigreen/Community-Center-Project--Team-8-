using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Center_Project__Team_8_
{
    public class PaymentView
    {
        public decimal Amount{ get; set; }

        public string Reason { get; set; }

        public int Id;
        public PaymentView(int id)
        {
            Id = id;
        }
        public bool Finalize => Amount > 0 && Reason.Length > 0;

        public void MakePayment()
        {

        }
    }
}
