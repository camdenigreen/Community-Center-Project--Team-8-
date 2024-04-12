using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class PastEvent
    {
        public int EventId { get; }

        public string Name { get; }

        public DateTime Date { get; }

        public int Registrants { get; }

        public int Attendees { get; }

        public double Percentage { get; }

        public int MTDRegistrants { get; }

        public int MTDAttendees { get; }

        public double MTDPercentage { get; }

        public PastEvent(int eventId, string name, DateTime date, int registrants, int attendees, double percentage, int mTDRegistrants, int mTDAttendees, double mTDPercentage)
        {
            EventId = eventId;
            Name = name;
            Date = date;
            Registrants = registrants;
            Attendees = attendees;
            Percentage = percentage;
            MTDRegistrants = mTDRegistrants;
            MTDAttendees = mTDAttendees;
            MTDPercentage = mTDPercentage;
        }
    }
}
