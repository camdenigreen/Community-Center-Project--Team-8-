using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrieveAllMembersDataDelegate : DataReaderDelegate<IReadOnlyList<Person>>
    {
        private readonly string _phoneNumber;

        private readonly string _lastName;

        public RetrieveAllMembersDataDelegate(string phoneNumber,string lastName)
            : base("People.RetrieveAllMembers")
        {
            _phoneNumber = phoneNumber;
            _lastName = lastName;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);
           // command.Parameters.AddWithValue("GroupID", _groupID is null ? (object)DBNull.Value : _groupID);
            command.Parameters.AddWithValue("PhoneNumber", String.IsNullOrEmpty(_phoneNumber) ? (object)DBNull.Value : _phoneNumber);
            command.Parameters.AddWithValue("LastName", String.IsNullOrEmpty(_lastName) ? (object)DBNull.Value : _lastName);


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

            return list;
        }
    }
}
