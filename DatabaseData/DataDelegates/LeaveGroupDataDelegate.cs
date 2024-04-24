using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class LeaveGroupDataDelegate : DataDelegate
    {
        private readonly int _personID;
        private readonly int _groupID;

        public LeaveGroupDataDelegate(int personID,int groupID)
            : base("People.LeaveGroup")
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
