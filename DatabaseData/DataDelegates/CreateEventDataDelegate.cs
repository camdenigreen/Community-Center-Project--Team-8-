using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataDelegates;
using System.Data;

namespace DatabaseData.DataDelegates
{
    public class CreateEventDataDelegate : NonQueryDataDelegate<Event>
    {
        private readonly string _eventName;

        private readonly int? _groupID;

        private readonly string _description;

        private readonly string _organizer;

        private readonly DateTime _date;

        private readonly decimal _charge;

        public CreateEventDataDelegate(string eventName, int? groupID, string description, string organizer, DateTime date, decimal charge)
            : base("Events.CreateEvent")
        {
            _eventName = eventName;
            _groupID = groupID;
            _description = description;
            _organizer = organizer;
            _date = date;
            _charge = charge;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", _eventName);
            command.Parameters.AddWithValue("GroupID", _groupID is null ? (object)DBNull.Value : _groupID);
            command.Parameters.AddWithValue("Description", _description);
            command.Parameters.AddWithValue("Organizer", _organizer);
            command.Parameters.AddWithValue("Date", _date);
            command.Parameters.AddWithValue("Charge", _charge);

            SqlParameter eventID = command.Parameters.Add("EventID", SqlDbType.Int);
            eventID.Direction = ParameterDirection.Output;
        }

        public override Event Translate(Command command)
        {
            return new Event(command.GetParameterValue<int>("EventID"), _eventName, _groupID, _description, _organizer, _date, _charge);
        }
    }
}
