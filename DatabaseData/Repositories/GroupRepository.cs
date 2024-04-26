using DataAccess;
using DatabaseData.DataDelegates;
using DatabaseData.Models;
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
            _executor.ExecuteNonQuery(data);
           
        }

        public Group CreateGroup(string name, string description)
        {
            CreateGroupDataDelegate data = new CreateGroupDataDelegate(name, description);
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

        public IReadOnlyList<ActiveGroup> RetrieveActiveMembers()
        {
            RetrieveActiveMembersDataDelegate data = new RetrieveActiveMembersDataDelegate();
            return _executor.ExecuteReader(data);
        }

        public void LeaveGroup(int personId,int groupId)
        {
            LeaveGroupDataDelegate data = new LeaveGroupDataDelegate(personId, groupId);
            _executor.ExecuteNonQuery(data);
        }

        public IReadOnlyList<Person> RetrievePeopleInGroup(int groupID)
        {
            RetrievePeopleByGroupIDDataDelegate data = new RetrievePeopleByGroupIDDataDelegate(groupID);
            return _executor.ExecuteReader(data);
        }

        public IReadOnlyList<Event> RetrieveEventsInGroup(int groupID)
        {
            RetrieveEventsByGroupIDDataDelegate data = new RetrieveEventsByGroupIDDataDelegate(groupID);
            return _executor.ExecuteReader(data);
        }
    }
}
