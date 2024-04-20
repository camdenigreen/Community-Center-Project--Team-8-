using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData;

namespace Community_Center_Project__Team_8_
{
    public  class PersonEventGroupEventArgs
    {

      
        public int Id { get; private set; }

        public bool Action { get; private set; }

        public string Type { get; private set; }
        
        public Group Group { get; private set; }

        public Event Event { get; private set; }
        public PersonEventGroupEventArgs(int id,bool action,string type)
        {
            Id = id;
            Action = action;

            Type = type;
                      
        }
        public PersonEventGroupEventArgs(int id, bool action, string type,Event even )
        {
            Id = id;
            Action = action;

            Type = type;
            Event = even;

        }

        public PersonEventGroupEventArgs(int id, bool action, string type, Group group)
        {
            Id = id;
            Action = action;

            Type = type;
            Group = group;

        }
    }
}
