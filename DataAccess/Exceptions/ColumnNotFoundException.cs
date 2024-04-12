using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Exceptions
{
    public class ColumnNotFoundException : Exception
    {
        public ColumnNotFoundException(string name, Exception innerException = null)
            : base(String.Format("The column [{0}] was not fouind in the result set.", innerException))
        {

        }
    }
}
