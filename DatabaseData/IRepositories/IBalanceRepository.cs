using DataAccess.DataDelegates;
using DatabaseData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.IRepositories
{
    public interface IBalanceRepository
    {

        decimal RetrieveBalance(int personId);

    }
}
