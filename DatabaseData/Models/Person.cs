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

        public string FirstName { get; }

        public string LastName { get;  }

        public string Address { get;  }

        public string PhoneNumber { get;  }

       // public byte IsMember { get; }

     

   
        public Person(int personId, string firstName, string lastName, string address, string phoneNumber)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            //IsMember = isMember;
        }

       
    }
}
