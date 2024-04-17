using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Center_Project__Team_8_
{
    public  class PersonEventGroupEventArgs
    {

      
        public int Id { get; private set; }

        public bool Action { get; private set; }

        public string Type { get; private set; }
        public PersonEventGroupEventArgs(int id,bool action,string type)
        {
            Id = id;
            Action = action;

            Type = type;
                      
        }
    }
}
