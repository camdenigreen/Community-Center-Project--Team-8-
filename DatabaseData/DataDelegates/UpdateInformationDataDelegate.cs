using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Sql.StoredProcedures
{
    public class UpdateInformationDataDelegate : DataDelegate
    {
        private readonly int _personID;

        private readonly string _address;

        private readonly string _firstName;

        private readonly string _lastName;

        private readonly string _phoneNumber;

        public UpdateInformationDataDelegate(int personID, string address, string firstName, string lastName, string phoneNumber)
            : base("People.UpdateInformation")
        {
            _personID = personID;
            _address = address;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("Address", _address);
            command.Parameters.AddWithValue("FirstName", _firstName);
            command.Parameters.AddWithValue("LastName", _lastName);
            command.Parameters.AddWithValue("PhoneNumber", _phoneNumber);
        }
    }
}
