using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class Event
    {
        public int EventID { get; }

        public string Name { get; }

        public int? GroupID { get; }

        public string Description { get; }

        public string Organizer { get; }

        public DateTime Date { get; }

        public decimal Charge { get; }

        public Event(int eventId, string name, int? groupId, string description, string organizer, DateTime date, decimal charge)
        {
            EventID = eventId;
            Name = name;
            GroupID = groupId == 0 ? null : groupId; //the reader returns nulls as default (0)
            Description = description;
            Organizer = organizer;
            Date = date;
            Charge = charge;
        }
    }
}
