using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrieveActiveMembersDataDelegate : DataReaderDelegate<IReadOnlyList<Person>>
    {
        public RetrieveActiveMembersDataDelegate()
            : base("People.RetrieveActiveMembers")
        {
        }

        public override IReadOnlyList<Person> Translate(Command command, IDataRowReader reader)
        {
            List<Person> list = new List<Person>();

            while (reader.Read())
            {
                list.Add(new Person(
                    reader.GetInt32("PersonID"),
                    reader.GetString("FirstName"),
                    reader.GetString("LastName"),
                    reader.GetString("Address"),
                    reader.GetString("PhoneNumber")));
                  
            }

            return list;
        }
    }
}
