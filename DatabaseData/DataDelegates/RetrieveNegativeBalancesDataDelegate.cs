using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataDelegates;
using DatabaseData.Models;

namespace DatabaseData.DataDelegates
{
    public class RetrieveNegativeBalancesDataDelegate : DataReaderDelegate<IReadOnlyList<PersonBalance>>
    {
        public RetrieveNegativeBalancesDataDelegate() : base("People.NegativeBalance")
        {
        }

        public override IReadOnlyList<PersonBalance> Translate(Command command, IDataRowReader reader)
        {
            List<PersonBalance> list = new List<PersonBalance>();

            while (reader.Read())
            {
                list.Add(new PersonBalance(
                    reader.GetInt32("PersonID"),
                    reader.GetString("FirstName"),
                    reader.GetString("LastName"),
                    reader.GetString("PhoneNumber"),
                    reader.GetValue<Decimal>("Balance")));
            }

            return list.AsReadOnly();
        }
    }
}
