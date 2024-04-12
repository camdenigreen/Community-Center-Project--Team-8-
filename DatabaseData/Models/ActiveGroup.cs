using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class ActiveGroup
    {
        public int GroupId { get; }

        public string Name { get; }

        public int TotalMembers { get; }

        public int ActiveMembers { get; }

        public double PercentageOfActiveMembers { get; }

        public ActiveGroup(int groupId, string name, int totalMembers, int activeMembers, double percentageOfActiveMembers)
        {
            GroupId = groupId;
            Name = name;
            TotalMembers = totalMembers;
            ActiveMembers = activeMembers;
            PercentageOfActiveMembers = percentageOfActiveMembers;
        }

        public ActiveGroup(Group group, int totalMembers, int activeMembers, double percentageOfActiveMembers) 
        {
            GroupId = group.GroupId;
            Name = group.Name;
            TotalMembers = totalMembers;
            ActiveMembers = activeMembers;
            PercentageOfActiveMembers = percentageOfActiveMembers;
        }
    }
}
