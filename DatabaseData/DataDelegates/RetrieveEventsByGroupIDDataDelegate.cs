using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataDelegates;

namespace DatabaseData.DataDelegates
{
    public class RetrieveEventsByGroupIDDataDelegate : DataReaderDelegate<IReadOnlyList<Event>>
    {
        private readonly int _groupID;
        public RetrieveEventsByGroupIDDataDelegate(int groupID) 
            : base("Events.RetrieveEventsByGroupID")
        {
            _groupID = groupID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("GroupID", _groupID);
        }

        public override IReadOnlyList<Event> Translate(Command command, IDataRowReader reader)
        {
            List<Event> list = new List<Event>();

            while (reader.Read())
            {
                list.Add(new Event(
                    reader.GetInt32("EventID"),
                    reader.GetString("Name"),
                    reader.GetInt32("GroupID"),
                    reader.GetString("Description"),
                    reader.GetString("Organizer"),
                    reader.GetDateTime("Date", DateTimeKind.Utc),
                    reader.GetValue<Decimal>("Charge")));
            }

            return list;
        }
    }
}
