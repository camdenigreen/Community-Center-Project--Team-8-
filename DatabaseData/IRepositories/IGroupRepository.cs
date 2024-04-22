using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.IRepository
{
    public interface IGroupRepository
    {
        IReadOnlyList<Group> RetrieveGroups(int? groupID, string groupName);

        IReadOnlyList<Group> RetrieveGroups(int personId);

        Group CreateGroup(string name, string Description);

        void AddPersonToGroup(int personId, string groupId);
    }
}
