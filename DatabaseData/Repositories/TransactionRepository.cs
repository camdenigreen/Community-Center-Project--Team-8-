using DataAccess;
using DatabaseData.DataDelegates;
using DatabaseData.IRepository;
using DatabaseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CommandExecutor _executor;

        public TransactionRepository(string connectionString)
        {
            _executor = new CommandExecutor(connectionString);
        }

        public Charge CreateCharge(int personId, int? eventId, decimal amount, string reason, DateTime date)
        {
            CreateChargeDataDelegate data = new CreateChargeDataDelegate(personId, amount, reason, date, eventId);
            return _executor.ExecuteNonQuery<Charge>(data);
        }

        public Payment CreatePayment(int personId, decimal amount, string reason, DateTime date)
        {
            CreatePaymentDataDelegate data = new CreatePaymentDataDelegate(personId, amount, reason, date);
            return _executor.ExecuteNonQuery<Payment>(data);
        }

        public IReadOnlyList<Charge> RetrieveCharges(int personId)
        {
            RetrieveChargesDataDelegate data = new RetrieveChargesDataDelegate(personId);
            return _executor.ExecuteReader<IReadOnlyList<Charge>>(data);
        }

        public IReadOnlyList<Payment> RetrievePayments(int personId)
        {
            RetrievePaymentsDataDelegate data = new RetrievePaymentsDataDelegate(personId);
            return _executor.ExecuteReader<IReadOnlyList<Payment>>(data);
        }

        public IReadOnlyList<Transaction> RetrieveTransactions(int personID)
        {
            RetrieveTransactionsDataDelegate data = new RetrieveTransactionsDataDelegate(personID);
            return _executor.ExecuteReader<IReadOnlyList<Transaction>>(data);
        }
    }
}
