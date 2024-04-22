using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataDelegates;
using DatabaseData.Models;

namespace DatabaseData.DataDelegates
{
    internal class RetrievePastEventsDataDelegate : DataReaderDelegate<IReadOnlyList<PastEvent>>
    {
        public RetrievePastEventsDataDelegate() : base("People.PreviousEventsAggregated")
        {
        }

        public override IReadOnlyList<PastEvent> Translate(Command command, IDataRowReader reader)
        {
            List<PastEvent> list = new List<PastEvent>();

            while (reader.Read())
            {
                list.Add(new PastEvent(
                    reader.GetInt32("EventID"),
                    reader.GetString("Name"),
                    reader.GetDateTime("Date", DateTimeKind.Utc),
                    reader.GetInt32("Registrants"),
                    reader.GetInt32("Attendees"),
                    reader.GetValue<Double>("AttendanceRatio"),
                    reader.GetInt32("MtdRegistrants"),
                    reader.GetInt32("MtdAttendees"),
                    reader.GetValue<Double>("MtdAttendenceRatio")
                    ));
            }

            return list.AsReadOnly();
        }
    }
}
