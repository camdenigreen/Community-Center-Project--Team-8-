using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class CreatePersonDataDelegate : NonQueryDataDelegate<Person>
    {
        private readonly string _firstName;

        private readonly string _lastName;

        private readonly string _phoneNumber;

        private readonly string _address;

        private readonly byte _isMember;

        public CreatePersonDataDelegate(string firstName, string lastName, string phoneNumber, string address, byte isMember)
            : base("People.CreatePerson")
        {
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _address = address;
            _isMember = isMember;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("FirstName", _firstName);
            command.Parameters.AddWithValue("LastName", _lastName);
            command.Parameters.AddWithValue("PhoneNumber", _phoneNumber);
            command.Parameters.AddWithValue("Address", _address);
           // command.Parameters.AddWithValue("IsMember", _isMember);

            SqlParameter parameter = command.Parameters.Add("PersonID", SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
        }

        public override Person Translate(Command command)
        {
            return new Person(command.GetParameterValue<int>("PersonID"), _firstName, _lastName, _address, _phoneNumber );
        }
    }
}
