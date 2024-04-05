using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public interface IChargeRepository
    {
        IReadOnlyList<Charge> RetreiveCharges(int personId);

        void CreateCharge(int personId, int? eventId, decimal amount, string reason, DateTime date);
    }
}
