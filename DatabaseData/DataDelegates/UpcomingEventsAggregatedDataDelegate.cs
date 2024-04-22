using DataAccess;
using DataAccess.DataDelegates;
using DatabaseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class UpcomingEventsAggregatedDataDelegate : DataReaderDelegate<IReadOnlyList<Event>>
    {
        public UpcomingEventsAggregatedDataDelegate()
            : base("Events.UpcomingEventsAggregated")
        {
        }

        public override IReadOnlyList<Event> Translate(Command command, IDataRowReader reader)
        {
            List<Event> list = new List<Event>();

            while (reader.Read())
            {
                list.Add(new EventRegistrants(
                    reader.GetInt32("EventID"),
                    reader.GetString("Name"),
                    reader.GetInt32("GroupID"),
                    reader.GetString("Description"),
                    reader.GetString("Organizer"),
                    reader.GetDateTime("Date", DateTimeKind.Utc),
                    reader.GetValue<decimal>("Charge"),
                    reader.GetInt32("Registrants")));
            }

            return list.AsReadOnly();
        }
    }
}
