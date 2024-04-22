using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class EventRegistrants : Event
    {
        public int Registrants { get; }

        public EventRegistrants(int eventID, string eventName, int? groupID, string description, string organizer, DateTime date, decimal charge, int registrants)
            : base(eventID, eventName, groupID, description, organizer, date, charge)
        {
            Registrants = registrants;
        }

        public EventRegistrants(Event e, int registrants)
            : base(e.EventID, e.Name, e.GroupID, e.Description, e.Organizer, e.Date, e.Charge)
        {
            Registrants = registrants;
        }
    }
}
