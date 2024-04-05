using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class Group
    {
        public int GroupId { get; }

        public string Name { get; }

        public string Description { get; }

        public Group(int groupId, string name, string description)
        {
            GroupId = groupId;
            Name = name;
            Description = description;
        }
    }
}
