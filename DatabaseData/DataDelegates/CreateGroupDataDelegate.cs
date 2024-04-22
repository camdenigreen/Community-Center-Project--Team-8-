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
    public class CreateGroupDataDelegate : NonQueryDataDelegate<Group>
    {
        private readonly string _name;

        private readonly string _description;

        public CreateGroupDataDelegate(string name, string description)
         : base("People.CreateGroup")
        {
            _name = name;
            _description = description;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", _name);
            command.Parameters.AddWithValue("Description", _description);

            SqlParameter groupID = command.Parameters.Add("GroupID", SqlDbType.Int);
            groupID.Direction = ParameterDirection.Output;
        }

        public override Group Translate(Command command)
        {
            return new Group(
                command.GetParameterValue<int>("GropuID"),
                _name,
                _description);
        }
    }
}
