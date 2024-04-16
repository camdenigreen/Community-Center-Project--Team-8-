using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData;

namespace Community_Center_Project__Team_8_
{
    public class PersonView : INotifyPropertyChanged
    {


        private Person _person;

        private int _id;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstname;
        public string  FirstName{
            get
            {
                return _firstname;
            }
            set
            {
                FirstName = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int Id { get; }




        private decimal _balance;
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            private set
            {
                _balance = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));
            }
        }
        public void SetBalance()
        {
            _balance = 0;
        }

        public decimal CalcBalance()
        {
            decimal res = 0;
            Balance = res;
            return 0;
        }

        public List<Group> MyGroups { get; }

        public List<Group> OtherGroups { get; }

        public Dictionary<string,DateTime> MyEvents { get; }

        public Dictionary<string,DateTime> OtherEvents { get; }

        public bool JoinGroup(int groupId)
        {
            return false;
        }

        public bool JoinEvent(int eventId)
        {
            return false;
        }

        public void LeaveGroup(int id)
        {

        }
        public void LeaveEvent(int id)
        {

        }

        public bool UpdateInfo(string firstName,string lastNmae,string phoneNumber, string address)
        {

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));

            return false;
        }
        public List<string> Transactions { get; }

        public string Info =>$"{FirstName} {LastName} #{Id.ToString()}";


        public bool MakePayment(decimal payment)
        {
            return false;
        }
        private decimal _paid=0;
        public decimal Paid
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Values must be >0");
                }
                else
                {
                    Paid = value; 
                }
            }

            get
            {
                return _paid;
            }
        }
        public bool Finalize { get; }

        //make sure that amount is >0 and paid >0 or not empty

        public void Delete()
        {

        }
        public PersonView(Person person)
        {
            _person = person;
            _firstname = person.FirstName;
            LastName = person.LastName;
            Address = person.Address;
            PhoneNumber = person.PhoneNumber;
            
            CalcBalance();
            //initialize groups and ......

        }
    }
}
