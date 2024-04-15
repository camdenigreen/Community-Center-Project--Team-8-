using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData;

namespace Community_Center_Project__Team_8_
{
    public class PersonView
    {

        private Person _person;

        public decimal Balance { get; }

        public decimal CalcBalance(int id)
        {
            return 0;
        }

        public List<string> MyGroups { get; }

        public List<string> OtherGroups { get; }

        public Dictionary<string,DateTime> MyEvent { get; }

        public Dictionary<string,DateTime> OtherEvents { get; }

        public bool JoinGroup()
        {
            return false;
        }

        public bool JoinEvent()
        {
            return false;
        }

        public bool UpdateInfo()
        {
            return false;
        }
        public List<string> Transactions { get; }


        public bool MakePayment()
        {
            return false;
        }
        public bool Finalize { get; }



        public PersonView(Person person)
        {
            _person = person;

        }
    }
}
