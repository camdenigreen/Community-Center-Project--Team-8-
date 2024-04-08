using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace DatabaseData
{
    public class PersonRepository : IPersonRepository
    {
        private readonly CommandExecutor _executor;

        public PersonRepository(string connectionString)
        {
            _executor = new CommandExecutor(connectionString);
        }

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
