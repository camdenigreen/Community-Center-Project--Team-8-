using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataDelegates;

namespace DatabaseData.DataDelegates
{
    public class RetrievePeopleByGroupIDDataDelegate : DataReaderDelegate<IReadOnlyList<Person>>
    {
        private readonly int _groupID;
        public RetrievePeopleByGroupIDDataDelegate(int groupId) 
            : base("People.RetrievePeopleByGroupID")
        {
            _groupID = groupId;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("GroupID", _groupID);
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
