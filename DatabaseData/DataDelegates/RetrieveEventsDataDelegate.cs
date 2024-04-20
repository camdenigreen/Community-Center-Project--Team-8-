using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrieveEventsDataDelegate : DataReaderDelegate<IReadOnlyList<Event>>
    {
        private readonly int? _eventID;

        private readonly string _eventName;

        public RetrieveEventsDataDelegate(int? eventID, string eventName)
            : base("Events.RetrieveEvents")
        {
            _eventID = eventID;
            _eventName = eventName;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("EventID", _eventID is null ? (object)DBNull.Value : _eventID);
            command.Parameters.AddWithValue("EventName", String.IsNullOrEmpty(_eventName) ? (object)DBNull.Value : _eventName);
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
                    reader.GetInt32("Charge")));
            }

            return list.AsReadOnly();
        }
    }
}
