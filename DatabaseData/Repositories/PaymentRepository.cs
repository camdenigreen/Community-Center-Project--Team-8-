using DataAccess;
using DatabaseData.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData.IRepository;
using DatabaseData.Models;

namespace DatabaseData
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CommandExecutor _executor;

        public PaymentRepository(string connectionString)
        {
            _executor = new CommandExecutor(connectionString);
        }

        public Payment CreatePayment(int personId, int? eventId, decimal amount, string reason, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Payment> RetrievePayments(int personID)
        {
            RetrievePaymentsDataDelegate data = new RetrievePaymentsDataDelegate(personID);
            return _executor.ExecuteReader(data);
        }
    }
}
