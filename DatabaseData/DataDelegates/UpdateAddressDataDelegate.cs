using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class UpdateAddressDataDelegate : DataDelegate
    {
        private readonly int _personID;

        private readonly string _address;

        public UpdateAddressDataDelegate(int personID, string address)
            : base("People.UpdateAddress")
        {
            _personID = personID;
            _address = address;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("Address", _address);
        }
    }
}
