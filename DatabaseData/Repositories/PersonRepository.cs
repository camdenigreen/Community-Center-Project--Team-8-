using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DatabaseData.DataDelegates;

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
            CreatePersonDataDelegate data = new CreatePersonDataDelegate(firstName, lastName, phoneNumber, address, isMember);
       
            return _executor.ExecuteReader<Person>((DataAccess.IDataDelegates.IDataReaderDelegate<Person>)data);
        }

        public Person FetchPerson(int personId)
        {
            FetchPersonDataDelegate data = new FetchPersonDataDelegate(personId);
            return _executor.ExecuteReader(data);
        }

        public Person GetPerson(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Person> RetrievePersons()
        {
            RetrieveAllMembersDataDelegate data = new RetrieveAllMembersDataDelegate();
            return _executor.ExecuteReader(data);
        }

        public IReadOnlyList<PersonBalance> RetrieveNegativeBalances()
        {
            RetrieveNegativeBalancesDataDelegate data = new RetrieveNegativeBalancesDataDelegate();
            return _executor.ExecuteReader(data);
        }
    }
}
