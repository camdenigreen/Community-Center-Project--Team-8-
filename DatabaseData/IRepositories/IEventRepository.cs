﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public interface IEventRepository
    {
        IReadOnlyList<Event> RetrieveEvents(int? eventID, string eventName);

        IReadOnlyList<Event> RetrieveEvents(int personId);

        Event CreateEvent(string name, int? groupId, string description, string organizer, DateTime date, decimal charge);

        void AddPersonToEvent(int personId, int eventId,decimal charge);

        void SetPersonsEventAttendance(int personId, int eventId, bool attended);

        void LeaveEvent(int personId, int eventId);
    }
}
