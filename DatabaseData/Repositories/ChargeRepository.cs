using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    internal class ChargeRepository : IChargeRepository
    {
        public Charge CreateCharge(int personId, int? eventId, decimal amount, string reason, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Charge> RetreiveCharges(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
