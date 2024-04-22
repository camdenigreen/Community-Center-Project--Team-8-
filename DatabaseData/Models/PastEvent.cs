using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class PastEvent : Event
    {
        public int Registrants { get; }

        public int Attendees { get; }

        public double Percentage { get; }

        public int MTDRegistrants { get; }

        public int MTDAttendees { get; }

        public double MTDPercentage { get; }

        public PastEvent(int eventID, string name, int? groupID, string description, string organizer, DateTime date, decimal charge, int registrants, int attendees, double percentage, int mTDRegistrants, int mTDAttendees, double mTDPercentage)
            : base(eventID, name, groupID, description, organizer, date, charge)
        {
            Registrants = registrants;
            Attendees = attendees;
            Percentage = percentage;
            MTDRegistrants = mTDRegistrants;
            MTDAttendees = mTDAttendees;
            MTDPercentage = mTDPercentage;
        }
    }
}
