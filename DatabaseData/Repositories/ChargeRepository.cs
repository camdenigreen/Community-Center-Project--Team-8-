using DataAccess;
using DatabaseData.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class ChargeRepository : IChargeRepository
    {
        private readonly CommandExecutor _executor;

        public ChargeRepository(string connectionString)
        {
            _executor = new CommandExecutor(connectionString);
        }

        public Charge CreateCharge(int personId, int? eventId, decimal amount, string reason, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Charge> RetrieveCharges(int personId)
        {
            RetrieveChargesDataDelegate data = new RetrieveChargesDataDelegate(personId);
            return _executor.ExecuteReader(data);
        }
    }
}
