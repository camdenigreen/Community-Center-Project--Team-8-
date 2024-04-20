using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrievePersonGroupsDataDelegate : DataReaderDelegate<IReadOnlyList<Group>>
    {
        private readonly int _personID;

        public RetrievePersonGroupsDataDelegate(int personID)
            : base("People.RetrievePersonGroups")
        {
            _personID = personID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
        }

        public override IReadOnlyList<Group> Translate(Command command, IDataRowReader reader)
        {
            List<Group> list = new List<Group>();

            while (reader.Read())
            {
                list.Add(new Group(
                    reader.GetInt32("GroupID"),
                    reader.GetString("Name"),
                    reader.GetString("Description")));
            }

            return list.AsReadOnly() ;
        }
    }
}
