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

        public DateTime Date { get; }


        public int Registrants { get; }

        public EventRegistrants(int eventId, string name, DateTime date, int registrants)
        {
            EventId = eventId;
            Name = name;
            Date = date;
            Registrants = registrants;
        }
    }
}
