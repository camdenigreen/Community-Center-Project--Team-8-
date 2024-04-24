﻿using DataAccess;
using DatabaseData.DataDelegates;
using DatabaseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class EventRepository : IEventRepository
    {
        private readonly CommandExecutor _executor;

        public EventRepository(string connectionString)
        {
            _executor = new CommandExecutor(connectionString);
        }

        public void AddPersonToEvent(int personId, int eventId)
        {
            throw new NotImplementedException();
        }

        public Event CreateEvent(string name, int groupId, string description, string organizer, DateTime date, decimal charge)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Event> RetrieveEvents(int? eventID, string eventName)
        {
            RetrieveEventsDataDelegate data = new RetrieveEventsDataDelegate(eventID, eventName);
            return _executor.ExecuteReader(data);
        }

        public IReadOnlyList<Event> RetrieveEvents(int personID)
        {
            RetrieveEventsByPersonIDDataDelegate data = new RetrieveEventsByPersonIDDataDelegate(personID);
            return _executor.ExecuteReader(data);
        }

        public IReadOnlyList<Event> RetrieveOtherEvents(int personID)
        {
            RetrieveOtherEventsDataDelegate data = new RetrieveOtherEventsDataDelegate(personID);
            return _executor.ExecuteReader(data);
        }

        public void SetPersonsEventAttendance(int personId, int eventId, bool attended)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<EventRegistrants> RetrieveEventAttendence()
        {
            RetrieveUpcomingEventsDataDelegate data = new RetrieveUpcomingEventsDataDelegate();
            return _executor.ExecuteReader(data);
        }

        public IReadOnlyList<PastEvent> RetrievePastEvents()
        {
            RetrievePastEventsDataDelegate data = new RetrievePastEventsDataDelegate();
            return _executor.ExecuteReader(data);
        }
    }
}
