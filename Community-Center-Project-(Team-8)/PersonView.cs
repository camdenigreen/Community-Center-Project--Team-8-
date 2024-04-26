using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DatabaseData;
using DatabaseData.Models;
using DatabaseData.Repositories;
using Group = DatabaseData.Group;

namespace Community_Center_Project__Team_8_
{
    public class PersonView : INotifyPropertyChanged
    {
        public EventRepository eventRepository= new EventRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
        public GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");

        public event PropertyChangedEventHandler PropertyChanged;

       
        public string  FirstName{ get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int Id { get; private set; }

        private decimal _balance;
        public decimal Balance => _balance;

        private TimeSpan refund_time = TimeSpan.FromDays(18);


        List<Group> _mygroups = new List<Group>();
        public List<Group> MyGroups => _mygroups;       
            

        List<Group> _othergroups = new List<Group>();

        public List<Group> OtherGroups =>_othergroups;
      

        List<Event> _myevents = new List<Event>();

        public List<Event> MyEvents => _myevents;
          

        List<Event> _otherevents = new List<Event>();

        public List<Event> OtherEvents=> _otherevents;
        

        public void JoinGroup(int groupId,Group group)
        {
        
            _othergroups.Remove(group);
            _mygroups.Add(group);
            groupRepository.AddPersonToGroup(Id, groupId);

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyGroups)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherGroups)));
        }

        public void JoinEvent(int eventId,Event even)
        {
            EventRepository eventRep = new EventRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            eventRep.AddPersonToEvent(Id, eventId,-even.Charge);
            _otherevents.Remove(even);
            _myevents.Add(even);
            _balance += even.Charge;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));
            Transaction transaction = new Transaction(-even.Charge,"Charge",DateTime.Now, even.Name);
            _transactions.Add(transaction);

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyEvents)));
           PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherEvents)));
            
        }
      
        public void LeaveGroup(int groupId,Group group)
        {
            GroupRepository groupRep= new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");

            groupRep.LeaveGroup(Id, groupId);
            _othergroups.Add(group);
            _mygroups.Remove(group);            

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyGroups)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherGroups)));

        }
        public void LeaveEvent(int eventId,Event even)
        {
            eventRepository.LeaveEvent(Id, eventId);
            _otherevents.Add(even);
            _myevents.Remove(even);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyEvents)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherEvents)));
            if((even.Date)-DateTime.Now >= refund_time)
            {
                Transaction transaction = new Transaction(even.Charge, "Refund", DateTime.Now, even.Name);
                _transactions.Add(transaction);
                _balance -= even.Charge;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));

            }

        }

        public void UpdateInfo(string firstName,string lastName,string phoneNumber, string address)
        {
            PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            personRepository.UpdateInformation(Id, address, firstName, lastName, phoneNumber);
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));          
            
        }

        private List<Transaction> _transactions=new List<Transaction>();
        public List<Transaction> Transactions => _transactions;
            
        public string Info =>$"{FirstName} {LastName} #{Id.ToString()}";


        public bool MakePayment(decimal payment,string reason,DateTime time)
        {
            _balance -= payment;
            Transaction transaction = new Transaction(-payment, "Payment", time, reason);
            _transactions.Add(transaction);
            
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));
            return false;
        }
 

        public void Delete()
        {
            PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            personRepository.UpdateMembership(Id);
        }
        public PersonView(Person person)
        {
          
            FirstName = person.FirstName;
            LastName = person.LastName;
            Address = person.Address;
            PhoneNumber = person.PhoneNumber;
            Id = person.PersonId;
            GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            IReadOnlyList<Group> groups = groupRepository.RetrieveGroups(Id);
            _mygroups.AddRange(groups);

            IReadOnlyList<Group> othergroups = groupRepository.RetrieveOtherGroups(Id);
            _othergroups.AddRange(othergroups);

            EventRepository eventRepository = new EventRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            IReadOnlyList<Event> events = eventRepository.RetrieveEvents(Id);
            _myevents.AddRange(events);

            IReadOnlyList<Event> otherevents = eventRepository.RetrieveOtherEvents(Id);
            _otherevents.AddRange(otherevents);

            TransactionRepository transactionRepository = new TransactionRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            IReadOnlyList<Transaction> transactions = transactionRepository.RetrieveTransactions(Id);
            _transactions.AddRange(transactions);

            BalanceRepository balanceRepository = new BalanceRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            _balance = -balanceRepository.RetrieveBalance(Id);
           


        }

        public PersonView(string firstname,string lastname, string address, string phonenumber)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            PhoneNumber = phonenumber;

        }
       

        private bool validphone()
        {
            
            string pattern = @"^\(\d{ 3}\) \d{ 7}";
            Regex regex = new Regex(pattern);
          
            Match match = regex.Match(PhoneNumber);

            return match.Success && PhoneNumber.Length==13;
        }

        public bool Finalize => FirstName.Length > 0 && LastName.Length > 0 && Address.Length > 0 && validphone();


    
    }
}
