using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrieveChargesByPersonIDDataDelegate : DataReaderDelegate<IReadOnlyList<Charge>>
    {
        private readonly int _personid;

        public RetrieveChargesByPersonIDDataDelegate(int personid)
            : base("Charges.RetrieveChargesByPersonID")
        {
            _personid = personid;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);
        }

        public override IReadOnlyList<Charge> Translate(Command command, IDataRowReader reader)
        {
            List<Charge> list = new List<Charge>();

            while (reader.Read())
            {
                list.Add(new Charge(
                    reader.GetInt32("ChargeID"),
                    _personid,
                    reader.GetInt32("EventID"),
                    reader.GetValue<decimal>("Amount"),
                    reader.GetString("Reason"),
                    reader.GetDateTime("Date", DateTimeKind.Utc)));
            }

            return list.AsReadOnly();
        }
    }
}
