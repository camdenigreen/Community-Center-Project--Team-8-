using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class UpdateFirstNameDataDelegate : DataDelegate
    {
        private readonly int _personID;

        private readonly string _firstName;

        public UpdateFirstNameDataDelegate(int personID, string firstName)
            : base("People.UpdateFirstName")
        {
            _personID = personID;
            _firstName = firstName;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("FirstName", _firstName);
        }
    }
}
