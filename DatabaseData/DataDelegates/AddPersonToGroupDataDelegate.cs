using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataDelegates;

namespace DatabaseData.DataDelegates
{
    public class AddPersonToGroupDataDelegate : DataDelegate
    {
        private readonly int _personID;

        private readonly int _groupID;

        public AddPersonToGroupDataDelegate(int personID, int groupID)
            : base("People.AddPersonToGroup")
        {
            _personID = personID;
            _groupID = groupID;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("GroupID", _groupID);
        }
    }
}
