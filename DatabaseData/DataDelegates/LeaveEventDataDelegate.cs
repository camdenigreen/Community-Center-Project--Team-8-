using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class LeaveEventDataDelegate : DataDelegate
    {
        private readonly int _personID;

        public LeaveEventDataDelegate(int personID)
            : base("People.LeaveEvent")
        {
            _personID = personID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
        }
    }
}
