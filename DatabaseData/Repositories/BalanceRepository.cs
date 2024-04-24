using DataAccess;
using DatabaseData.DataDelegates;
using DatabaseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Repositories
{
    public class BalanceRepository
    {
        private readonly CommandExecutor _executor;

        public BalanceRepository(string connectionString)
        {
            _executor = new CommandExecutor(connectionString);
        }


        public decimal RetrieveBalance(int personID)
        {
            RetrieveBalanceDataDelegate data = new RetrieveBalanceDataDelegate(personID);
            return _executor.ExecuteReader(data);
        }
    }
}
