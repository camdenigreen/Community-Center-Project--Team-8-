using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public interface IPaymentRepository
    {
        IReadOnlyList<Payment> RetrievePayments(int personId);

        Payment CreatePayment(int personId, int? eventId, decimal amount, string reason, DateTime date);
    }
}
