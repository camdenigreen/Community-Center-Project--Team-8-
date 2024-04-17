using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData;
using DatabaseData.Models;

namespace Community_Center_Project__Team_8_
{
    public class PersonView : INotifyPropertyChanged
    {


       // private Person _person;

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
                _firstname = value;
               PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int Id { get; private set; }




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
      //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));
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

            //PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));
            GetTransactions();
            //PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Transactions)));
            return 0;
        }
        List<Group> _mygroups = new List<Group>();
        public List<Group> MyGroups { private set 
            
            {
                
                //query the database for groups based on id

            }
            get {
                return _mygroups;
            
            }
        }

        List<Group> _othergroups = new List<Group>();

        public List<Group> OtherGroups { private set 
            {
              

            } get
            {
                return _othergroups;
              }
             }

        List<Event> _myevents = new List<Event>();

        public List<Event> MyEvents {
            private set
            { 
            
            } get
            {
                return _myevents;
            }
        }

        List<Event> _otherevents = new List<Event>();

        public List<Event> OtherEvents { private set 
            {
                
            }
            get
            {

                return _otherevents;
            }
        }

        public bool JoinGroup(int groupId)
        {

            GetOtherGroups();
            GetMyGroups();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyGroups)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherGroups)));


            return false;
        }

        public bool JoinEvent(int eventId)
        {

            GetOtherEvents();
            GetMyEvents();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyEvents)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherEvents)));
            return false;
        }

        public void LeaveGroup(int id)
        {

            GetOtherGroups();
            GetMyGroups();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyGroups)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherGroups)));

        }
        public void LeaveEvent(int id)
        {

        }

        public void UpdateInfo(string firstName,string lastName,string phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));

            
        }

        private List<Transaction> _transactions=new List<Transaction>();
        public List<Transaction> Transactions
        {
            set
            {

            }

            get
            {
                return _transactions;
            }
        }
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
           // _person = person;
            _firstname = person.FirstName;
            LastName = person.LastName;
            Address = person.Address;
            PhoneNumber = person.PhoneNumber;
            Id = person.PersonId;
            CalcBalance();
            GetMyGroups();
            GetOtherGroups();
            GetOtherEvents();
            GetMyEvents();
            GetTransactions();
            //initialize groups and ......

        }
        private void GetMyGroups()
        {
            _mygroups.Clear();
            for(int i = 0; i < 5; i++)
            {
                Group group = new Group (i, "group", "we are a group");
                _mygroups.Add(group);
            }
            

        }

        private void GetOtherGroups()
        {
            _othergroups.Clear();
            for (int i = 0; i < 5; i++)
            {
                Group group = new Group(i, "group", "we are a group");
                _othergroups.Add(group);
            }


        }

        private void GetOtherEvents()
        {
            _otherevents.Clear();
            for(int i = 0; i < 5; i++)
            {
                Event even = new Event(i, "eventname", i, "description0", "organizer", DateTime.Now, 3.5m);
                _otherevents.Add(even);
            }

        }

        private void GetMyEvents()
        {
            _otherevents.Clear();
            for (int i = 0; i < 5; i++)
            {
                Event even = new Event(i, "eventname", i, "description0", "organizer", DateTime.Now, 3.5m);
                _myevents.Add(even);
            }

        }

        public void GetTransactions()
        {

            _transactions.Clear();
            for(int i = 0; i < 5; i++)
            {
                Transaction transaction = new Transaction(i, 3.5m + i, "Payment", DateTime.Now, "event");
                _transactions.Add(transaction);
            }
        }
    }
}
