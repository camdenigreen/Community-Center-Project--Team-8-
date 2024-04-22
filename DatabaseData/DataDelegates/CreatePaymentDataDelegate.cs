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
    public class CreatePaymentDataDelegate : NonQueryDataDelegate<Payment>
    {
        private readonly int _personID;

        private readonly decimal _amount;

        private readonly string _reason;

        private readonly DateTime _date;

        public CreatePaymentDataDelegate(int personID, decimal amount, string reason, DateTime date)
            : base("People.CreatePayment")
        {
            _personID = personID;
            _amount = amount;
            _reason = reason;
            _date = date;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("Amount", _amount);
            command.Parameters.AddWithValue("Reason", _reason);
            command.Parameters.AddWithValue("Date", _date);

            SqlParameter paymentID = command.Parameters.Add("PaymentID", SqlDbType.Int);
            paymentID.Direction = ParameterDirection.Output;
        }

        public override Payment Translate(Command command)
        {
            return new Payment(
                command.GetParameterValue<int>("PaymentID"),
                _personID,
                _amount,
                _reason,
                _date);
        }
    }
}
