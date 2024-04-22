using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataDelegates;

namespace DatabaseData.DataDelegates
{
    public class UpdateEventAttendanceDataDelegate : DataDelegate
    {
        public readonly int _personID;

        public readonly int _eventID;

        public UpdateEventAttendanceDataDelegate(int personID, int eventID)
            : base("Events.UpdateEventAttendance")
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
