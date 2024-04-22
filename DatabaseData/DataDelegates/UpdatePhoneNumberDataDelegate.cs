using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class UpdatePhoneNumberDataDelegate : DataDelegate
    {
        private readonly int _personID;

        private readonly string _phoneNumber;

        public UpdatePhoneNumberDataDelegate(int personID, string phoneNumber)
            : base("People.UpdatePhoneNumber")
        {
            _personID = personID;
            _phoneNumber = phoneNumber;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("PhoneNumber", _phoneNumber);
        }
    }
}
