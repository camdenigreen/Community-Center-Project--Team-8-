using DataAccess;
using DataAccess.DataDelegates;
using DatabaseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrieveTransactionsDataDelegate : DataReaderDelegate<IReadOnlyList<Transaction>>
    {
        private readonly int _personID;

        public RetrieveTransactionsDataDelegate(int personID)
            : base("People.RetrieveTransactions")
        {
            _personID = personID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
        }

        public override IReadOnlyList<Transaction> Translate(Command command, IDataRowReader reader)
        {
            List<Transaction> list = new List<Transaction>();

            while (reader.Read())
            {
                list.Add(new Transaction(
                    reader.GetInt32("ID"),
                    reader.GetValue<decimal>("Amount"),
                    reader.GetString("Type"),
                    reader.GetDateTime("Date", DateTimeKind.Utc),
                    reader.GetString("Reason")));
            }

            return list;
        }
    }
}
