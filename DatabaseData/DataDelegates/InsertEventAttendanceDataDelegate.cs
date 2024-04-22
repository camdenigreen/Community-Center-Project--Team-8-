using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class InsertEventAttendanceDataDelegate : DataDelegate
    {
        private readonly int _personID;

        private readonly int? _eventID;

        private readonly int _didAttend;

        private readonly decimal _amount;

        public InsertEventAttendanceDataDelegate(int personID, int? eventID, int didAttend, decimal amount)
            : base("Events.InsertEventAttendance")
        {
            _personID = personID;
            _eventID = eventID;
            _didAttend = didAttend;
            _amount = amount;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("EventID", _eventID is null ? (object)DBNull.Value : _eventID);
            command.Parameters.AddWithValue("DidAttend", _didAttend);
            command.Parameters.AddWithValue("Amount", _amount);
        }
    }
}
