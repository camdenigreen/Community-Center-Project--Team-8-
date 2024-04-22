using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData.Models;

namespace DatabaseData.IRepository
{
    public interface ITransactionRepository
    {
        IReadOnlyList<Payment> RetrievePayments(int personId);

        IReadOnlyList<Charge> RetrieveCharges(int personId);

        IReadOnlyList<Transaction> RetrieveTransactions(int personID);

        Payment CreatePayment(int personId, decimal amount, string reason, DateTime date);

        Charge CreateCharge(int personId, int? eventId, decimal amount, string reason, DateTime date);
    }
}
