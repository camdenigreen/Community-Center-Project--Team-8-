using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataDelegates
{
    public abstract class DataDelegate : IDataDelegate
    {
        public string ProcedureName { get; }

        protected DataDelegate(string procedureName)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
            {
                throw new ArgumentException("Procedure Name Cannot Be Null Or Empty", nameof(procedureName));
            }

            ProcedureName = procedureName;
        }

        public abstract void PrepareCommand(Command command);
    }
}
