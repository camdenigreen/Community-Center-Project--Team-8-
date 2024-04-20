using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class PersonsEvent : Event
    {
        public bool DidAttend { get; }

        public PersonsEvent(int eventId, string name, int? groupId, string description, string organizer, DateTime date, decimal charge, bool didAttend)
            : base(eventId, name, groupId, description, organizer, date, charge)
        {
            DidAttend = didAttend;
        }
    }
}
