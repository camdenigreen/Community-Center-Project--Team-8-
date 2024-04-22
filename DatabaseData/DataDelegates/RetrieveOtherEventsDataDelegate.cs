using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrieveOtherEventsDataDelegate : DataReaderDelegate<IReadOnlyList<Event>>
    {
        private readonly int _personID;

        public RetrieveOtherEventsDataDelegate(int personID)
            : base("People.RetrieveOtherEvents")
        {
            _personID = personID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
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
                    reader.GetValue<decimal>("Charge")));
            }

            return list.AsReadOnly();
        }
    }
}
