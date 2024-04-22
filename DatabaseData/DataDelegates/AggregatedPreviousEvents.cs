using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class AggregatedPreviousEvents : DataReaderDelegate<IReadOnlyList<Event>>
    {
        public AggregatedPreviousEvents()
            : base("People.AggregatedPreviousEvents")
        {
        }

        public override IReadOnlyList<Event> Translate(Command command, IDataRowReader reader)
        {
            List<Event> list = new List<Event>();

            while (reader.Read())
            {
                
            }

            return list;
        }
    }
}
