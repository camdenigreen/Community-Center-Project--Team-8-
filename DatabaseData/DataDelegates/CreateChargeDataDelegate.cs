using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseData.DataDelegates
{
    public class CreateChargeDataDelegate : NonQueryDataDelegate<Charge>
    {
        private readonly int _personID;

        private readonly decimal _amount;

        private readonly string _reason;

        private readonly DateTime _date;

        private readonly int? _eventID;

        public CreateChargeDataDelegate(int personID, decimal amount, string reason, DateTime date, int? eventID)
            : base("People.CreateCharge")
        {
            _personID = personID;
            _amount = amount;
            _reason = reason;
            _date = date;
            _eventID = eventID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("Amount", _amount);
            command.Parameters.AddWithValue("Reason", _reason);
            command.Parameters.AddWithValue("Date", _date);
            command.Parameters.AddWithValue("EventID", _eventID is null ? (object)DBNull.Value : _eventID);

            SqlParameter chargeID = command.Parameters.Add("ChargeID", SqlDbType.Int);
            chargeID.Direction = ParameterDirection.Output;
        }

        public override Charge Translate(Command command)
        {
            return new Charge(
                command.GetParameterValue<int>("ChargeID"),
                _personID,
                _eventID,
                _amount,
                _reason,
                _date);
        }
    }
}
