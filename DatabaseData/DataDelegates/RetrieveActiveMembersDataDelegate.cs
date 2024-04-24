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
    public class RetrieveActiveMembersDataDelegate : DataReaderDelegate<IReadOnlyList<ActiveGroup>>
    {
        public RetrieveActiveMembersDataDelegate()
            : base("People.RetrieveActiveMembers")
        {
        }

        public override IReadOnlyList<ActiveGroup> Translate(Command command, IDataRowReader reader)
        {
            List<ActiveGroup> list = new List<ActiveGroup>();

            while (reader.Read())
            {
                list.Add(new ActiveGroup(
                    reader.GetInt32("GroupID"),
                    reader.GetString("Name"),
                    reader.GetString("Description"),
                    reader.GetInt32("TotalMembers"),
                    reader.GetInt32("ActiveMembers"),
                    reader.GetValue<Double>("PercentageOfActiveMembers")));  
            }

            return list;
        }
    }
}
