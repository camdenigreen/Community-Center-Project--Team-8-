using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class EventRegistrants
    {
        public int EventId { get; }

        public string Name { get; }

        public int? GroupId { get; }

        public string Description { get; }

        public string Organizer { get; }

        public DateTime Date { get; }

        public decimal Charge { get; }

        public int Registrants { get; }

        public EventRegistrants(int eventId, string name, int? groupId, string description, string organizer, DateTime date, decimal charge, int registrants)
        {
            EventId = eventId;
            Name = name;
            GroupId = groupId;
            Description = description;
            Organizer = organizer;
            Date = date;
            Charge = charge;
            Registrants = registrants;
        }

        public EventRegistrants(Event e, int registrants)
        {
            EventId = e.EventId;
            Name = e.Name;
            GroupId = registrants;
            Description = e.Description;
            Organizer = e.Organizer;
            Date = e.Date;
            Charge = e.Charge;
            Registrants = registrants;
        }
    }
}
