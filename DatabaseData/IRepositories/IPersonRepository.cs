using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public interface IPersonRepository
    {
        IReadOnlyList<Person> RetrievePersons();

        Person FetchPerson(int personId);

        Person GetPerson(string phoneNumber);

        Person CreatePerson(string firstName, string lastName, string address, string phoneNumber, byte isMember);

       void UpdateInformation(int personId, string address, string firstName, string lastName, string phoneNumber);

        void UpdateMembership(int personId);
    }
}
