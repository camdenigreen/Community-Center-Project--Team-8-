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
    public class RetrieveEventsByPersonIDDataDelegate : DataReaderDelegate<IReadOnlyList<PersonsEvent>>
    {
        private readonly int _personID;

        public RetrieveEventsByPersonIDDataDelegate(int personID)
            : base("Events.RetrieveEventsByPersonID")
        {
            _personID = personID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
        }

        public override IReadOnlyList<PersonsEvent> Translate(Command command, IDataRowReader reader)
        {
            List<PersonsEvent> list = new List<PersonsEvent>();

            while (reader.Read())
            {
                list.Add(new PersonsEvent(
                    reader.GetInt32("EventID"),
                    reader.GetString("Name"),
                    reader.GetInt32("GroupID"),
                    reader.GetString("Description"),
                    reader.GetString("Organizer"),
                    reader.GetDateTime("Date", DateTimeKind.Utc),
                    reader.GetInt32("Charge"),
                    reader.GetBoolean("DidAttend")));
            }

            return list.AsReadOnly();
        }
    }
}
