using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class LeaveEventDataDelegate : DataDelegate
    {
        private readonly int _personID;
        private readonly int _eventID;

        public LeaveEventDataDelegate(int personID,int eventID)
            : base("People.LeaveEvent")
        {
            _personID = personID;
            _eventID = eventID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("EventID", _eventID);
        }
    }
}
