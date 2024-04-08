using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class GetPersonDataDelegate : DataReaderDelegate<Person>
    {
        private readonly string _phoneNumber;

        public GetPersonDataDelegate(string phoneNumber)
            : base("Person.FetchPerson")
        {
            _phoneNumber = phoneNumber;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PhoneNumber", _phoneNumber);
        }

        public override Person Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }

            return new Person(
                reader.GetInt32("PersonID"),
                reader.GetString("FirstName"),
                reader.GetString("LastName"),
                reader.GetString("Address"),
                _phoneNumber,
                reader.GetByte("IsMember"));
        }
    }
}
