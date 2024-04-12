using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class PersonBalance
    {
        public int PersonId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Address { get; }

        public string PhoneNumber { get; }

        public byte IsMember { get; }

        public decimal Balance { get; }

        public PersonBalance(int personId, string firstName, string lastName, string address, string phoneNumber, byte isMember, decimal balance)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            IsMember = isMember;
            Balance = balance;
        }

        public PersonBalance(Person person, decimal balance)
        {
            PersonId = person.PersonId;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Address = person.Address;
            PhoneNumber = person.PhoneNumber;
            IsMember = person.IsMember;
            Balance = balance;
        }
    }
}
