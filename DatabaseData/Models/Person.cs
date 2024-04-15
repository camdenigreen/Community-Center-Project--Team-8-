using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData
{
    public class Person
    {
        public int PersonId { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public byte IsMember { get; set; }

     

   
        public Person(int personId, string firstName, string lastName, string address, string phoneNumber, byte isMember)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            IsMember = isMember;
        }

       
    }
}
