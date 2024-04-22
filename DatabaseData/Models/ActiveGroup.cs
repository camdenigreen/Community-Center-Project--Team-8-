using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class ActiveGroup : Group
    {
        public int TotalMembers { get; }

        public int ActiveMembers { get; }

        public double PercentageOfActiveMembers { get; }

        public ActiveGroup(int groupID, string name, string description, int totalMembers, int activeMembers, double percentageOfActiveMembers)
            : base(groupID, name, description)
        {
            TotalMembers = totalMembers;
            ActiveMembers = activeMembers;
            PercentageOfActiveMembers = percentageOfActiveMembers;
        }

        public ActiveGroup(Group g, int totalMembers, int activeMembers, double percentageOfActiveMembers)
            : base(g.GroupId, g.Name, g.Description)
        {
            TotalMembers = totalMembers;
            ActiveMembers = activeMembers;
            PercentageOfActiveMembers = percentageOfActiveMembers;
        }
    }
}
