using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class EventRepository : IEventRepository
    {
        public void CreateEvent(string name, int groupId, string description, string organizer, DateTime date, decimal charge)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Event> RetrieveEvents()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Event> RetrieveEvents(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
