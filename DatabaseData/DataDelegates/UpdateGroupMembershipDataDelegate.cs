using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class UpdateGroupMembershipDataDelegate : DataDelegate
    {
        private readonly int _personID;

        private readonly string _groupName;

        private readonly string _previousGroup;

        public UpdateGroupMembershipDataDelegate(int personID, string groupName, string previousGroup)
            : base("People.UpdateGroupMembership")
        {
            _personID = personID;
            _groupName = groupName;
            _previousGroup = previousGroup;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("GroupName", _groupName);
            command.Parameters.AddWithValue("PreviousGroup", _previousGroup);
        }
    }
}
