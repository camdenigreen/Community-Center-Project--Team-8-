using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class GroupRepository : IGroupRepository
    {
        public void AddPersonToGroup(int personId, string groupId)
        {
            throw new NotImplementedException();
        }

        public Group CreateGroup(string name, string Description)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Group> RetrieveGroups()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Group> RetrieveGroups(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
