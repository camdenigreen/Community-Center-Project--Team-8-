using DataAccess;
using DatabaseData.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class GroupRepository : IGroupRepository
    {
        private readonly CommandExecutor _executor;

        public GroupRepository(string connectionString)
        {
            _executor = new CommandExecutor(connectionString);
        }

        public void AddPersonToGroup(int personId, int groupId)
        {
            AddPersonToGroupDataDelegate data = new AddPersonToGroupDataDelegate(personId, groupId);
           
        }

        public Group CreateGroup(string name, string Description)
        {
            CreateGroupDataDelegate data = new CreateGroupDataDelegate(name, Description);
            return _executor.ExecuteNonQuery(data);
        }

        public IReadOnlyList<Group> RetrieveGroups(int? groupID, string groupName)
        {
            RetrieveGroupsDataDelegate data = new RetrieveGroupsDataDelegate(groupID, groupName);
            return _executor.ExecuteReader(data);
        }

        public IReadOnlyList<Group> RetrieveGroups(int personID)
        {
            RetrievePersonGroupsDataDelegate data = new RetrievePersonGroupsDataDelegate(personID);
            return _executor.ExecuteReader(data);
        }
        public IReadOnlyList<Group> RetrieveOtherGroups(int personID)
        {
            RetrievePersonOtherGroupsDataDelegate data = new RetrievePersonOtherGroupsDataDelegate(personID);
            return _executor.ExecuteReader(data);
        }

        public void LeaveGroup(int personId,int groupId)
        {
            LeaveGroupDataDelegate data = new LeaveGroupDataDelegate(personId, groupId);
         
        }
    }
}
