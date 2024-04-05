using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    internal interface IGroupRepository
    {
        IReadOnlyList<Group> RetrieveGroups();

        IReadOnlyList<Group> RetrieveGroups(int personId);

        void CreateGroup(string name, string Description);
    }
}
