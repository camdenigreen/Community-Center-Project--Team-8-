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
        private readonly int? _personID;

        private readonly string _firstName;

        private readonly string _lastName;

        private readonly string _phoneNumber;

        public RetrieveAllMembersDataDelegate()
            : base("People.RetrieveAllMembers")
        {
            /*_personID = personID;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;*/
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);
            /*
            command.Parameters.AddWithValue("PersonID", _personID is null ? (object)DBNull.Value : _personID);
            command.Parameters.AddWithValue("FirstName", String.IsNullOrEmpty(_firstName) ? (object)DBNull.Value : _firstName);
            command.Parameters.AddWithValue("LastName", String.IsNullOrEmpty(_lastName) ? (object)DBNull.Value : _lastName);
            command.Parameters.AddWithValue("PhoneNumber", String.IsNullOrEmpty(_phoneNumber) ? (object)DBNull.Value : _phoneNumber);*/
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
                    reader.GetString("Address")));
            }

            return list;
        }
    }
}
