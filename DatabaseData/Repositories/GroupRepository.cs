﻿using DataAccess;
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

        public void AddPersonToGroup(int personId, string groupId)
        {
            throw new NotImplementedException();
        }

        public Group CreateGroup(string name, string Description)
        {
            throw new NotImplementedException();
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
    }
}
