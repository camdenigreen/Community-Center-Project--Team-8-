using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData;

namespace Community_Center_Project__Team_8_
{
    /// <summary>
    /// custom event to handle accessing a person
    /// </summary>
    public  class AccessPersonEventArgs
    {
        /// <summary>
        /// sets and returns the person to be accessed
        /// </summary>
        public Person Person
        {
            get;private set;
        }
        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="person">the person to be accessed </param>
        public AccessPersonEventArgs(Person person)
        {
            Person = person;
        }
    }
}
