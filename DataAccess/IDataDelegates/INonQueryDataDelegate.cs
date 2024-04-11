using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDataDelegates
{
    public interface INonQueryDataDelegate<out T> : IDataDelegate
    {
        T Translate(Command command);
    }
}
