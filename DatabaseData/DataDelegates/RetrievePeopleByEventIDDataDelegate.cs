using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataDelegates;

namespace DatabaseData.DataDelegates
{
    public class RetrievePeopleByEventIDDataDelegate : DataReaderDelegate<IReadOnlyList<Person>>
    {
        private readonly int _eventID;
        public RetrievePeopleByEventIDDataDelegate(int eventID) 
            : base("Events.RetrievePeopleByEventID")
        {
            _eventID = eventID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("EventID", _eventID);
        }

        public override IReadOnlyList<Person> Translate(Command command, IDataRowReader reader)
        {
            List<Person> list = new List<Person>();

            while (reader.Read())
            {
                list.Add(new Person(
                reader.GetInt32("PersonID"),
                reader.GetString("FirstName"),
                reader.GetString("LastName"),
                reader.GetString("Address"),
                reader.GetString("PhoneNumber")));
            }

            return list.AsReadOnly();
        }
    }
}
