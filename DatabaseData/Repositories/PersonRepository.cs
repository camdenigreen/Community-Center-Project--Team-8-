﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class PersonRepository : IPaymentRepository
    {
        public void CreatePayment(int personId, int? eventId, decimal amount, string reason, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Charge> RetrievePayments(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
