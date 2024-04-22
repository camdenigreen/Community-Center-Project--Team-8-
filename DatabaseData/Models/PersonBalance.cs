using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class PersonBalance
    {
        public int PersonId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string PhoneNumber { get; }

        public decimal Balance { get; }

        public PersonBalance(int personId, string firstName, string lastName, string phoneNumber, decimal balance)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Balance = balance;
        }

        public PersonBalance(Person person, decimal balance)
        {
            PersonId = person.PersonId;
            FirstName = person.FirstName;
            LastName = person.LastName;
            PhoneNumber = person.PhoneNumber;
            Balance = balance;
        }
    }
}
