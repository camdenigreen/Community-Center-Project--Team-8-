using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrievePaymentsDataDelegate : DataReaderDelegate<IReadOnlyList<Payment>>
    {
        private readonly int _personID;

        public RetrievePaymentsDataDelegate(int personID)
            : base("People.RetrievePayments")
        {
            _personID = personID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
        }

        public override IReadOnlyList<Payment> Translate(Command command, IDataRowReader reader)
        {
            List<Payment> list = new List<Payment>();

            while (reader.Read())
            {
                list.Add(new Payment(
                    reader.GetInt32("PaymentID"),
                    reader.GetInt32("PersonID"),
                    reader.GetValue<decimal>("Amount", 0.00m),
                    reader.GetString("Reason"),
                    reader.GetDateTime("Date", DateTimeKind.Utc)));
            }

            return list.AsReadOnly();
        }
    }
}
