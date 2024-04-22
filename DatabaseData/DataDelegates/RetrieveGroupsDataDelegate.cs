using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class RetrieveGroupsDataDelegate : DataReaderDelegate<IReadOnlyList<Group>>
    {
        private readonly int? _groupID;

        private readonly string _groupName;

        public RetrieveGroupsDataDelegate(int? groupID, string groupName)
            : base("People.RetrieveGroups")
        {
            _groupID = groupID;
            _groupName = groupName;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("GroupID", _groupID is null ? (object)DBNull.Value : _groupID);
            command.Parameters.AddWithValue("GroupName", String.IsNullOrEmpty(_groupName) ? (object)DBNull.Value : _groupName);
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

            return list.AsReadOnly();
        }
    }
}
