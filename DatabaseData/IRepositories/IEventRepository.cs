using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public interface IEventRepository
    {
        IReadOnlyList<Event> RetrieveEvents();

        IReadOnlyList<Event> RetrieveEvents(int personId);

        void CreateEvent(string name, int groupId, string description, string organizer, DateTime date, decimal charge);
    }
}
