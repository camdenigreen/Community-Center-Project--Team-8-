using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class PersonRepository : IPersonRepository
    {
        public Person CreatePerson(string firstName, string lastName, string address, string phoneNumber, byte isMember)
        {
            throw new NotImplementedException();
        }

        public Person FetchPerson(int personId)
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Person> RetrievePersons()
        {
            throw new NotImplementedException();
        }
    }
}
