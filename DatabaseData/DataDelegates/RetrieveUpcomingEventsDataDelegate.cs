using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData.Models;
using DataAccess;
using DataAccess.DataDelegates;

namespace DatabaseData.DataDelegates
{
    public class RetrieveUpcomingEventsDataDelegate : DataReaderDelegate<IReadOnlyList<EventRegistrants>>
    {
        public RetrieveUpcomingEventsDataDelegate() : base("Events.UpcomingEventsAggregated")
        {
        }

        public override IReadOnlyList<EventRegistrants> Translate(Command command, IDataRowReader reader)
        {
            List<EventRegistrants> list = new List<EventRegistrants>();

            while (reader.Read())
            {
                list.Add(new EventRegistrants(
                    reader.GetInt32("EventID"),
                    reader.GetString("Name"),
                    reader.GetDateTime("Date", DateTimeKind.Utc),
                    reader.GetInt32("Registrants")));
            }

            return list.AsReadOnly();
        }
    }
}
