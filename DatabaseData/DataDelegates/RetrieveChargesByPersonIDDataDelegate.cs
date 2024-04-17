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
    public class RetrieveChargesByPersonIDDataDelegate : DataReaderDelegate<IReadOnlyList<Charge>>
    {
        private readonly int _personId;

        public RetrieveChargesByPersonIDDataDelegate(int personid)
            : base("People.RetrieveChargesByPersonID")
        {
            _personId = personid;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            SqlParameter p = command.Parameters.Add("PersonID", SqlDbType.Int);
            p.Value = _personId;
        }

        public override IReadOnlyList<Charge> Translate(Command command, IDataRowReader reader)
        {
            List<Charge> list = new List<Charge>();

            while (reader.Read())
            {
                list.Add(new Charge(
                    reader.GetInt32("ChargeID"),
                    _personId,
                    reader.GetInt32("EventID"),
                    reader.GetValue<decimal>("Amount"),
                    reader.GetString("Reason"),
                    reader.GetDateTime("Date", DateTimeKind.Utc)));
            }

            return list.AsReadOnly();
        }
    }
}
