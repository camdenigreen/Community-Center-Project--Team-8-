using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Models
{
    public class PersonBalance : Person
    {
        public decimal Balance { get; }

        public PersonBalance(int personID, string firstName, string lastName, string address, string phoneNumber, byte isMember, decimal balance)
            : base(personID, firstName, lastName, address, phoneNumber, isMember)
        {
            Balance = balance;
        }

        public PersonBalance(Person p, decimal balance)
            : base(p.PersonId, p.FirstName, p.LastName, p.Address, p.PhoneNumber, p.IsMember)
        {
            Balance = balance;
        }
    }
}
