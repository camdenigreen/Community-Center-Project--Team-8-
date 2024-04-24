﻿using System;
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
                // _balance = value;

                //CalcBalance();

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));
            }
        }
        public void SetBalance()
        {
            _balance = 0;
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

        public bool JoinGroup(int groupId,Group group)
        {

           // GetOtherGroups();
            //GetMyGroups();
            _othergroups.Remove(group);
            _mygroups.Add(group);
            //GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            groupRepository.AddPersonToGroup(Id, groupId);

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyGroups)));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherGroups)));


            return false;
        }

        public void JoinEvent(int eventId,Event even)
        {
            eventRepository.AddPersonToEvent(Id, eventId,even.Charge);
            _otherevents.Remove(even);
            _myevents.Add(even);
            _balance += even.Charge;
                      
           PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MyEvents)));
           PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherEvents)));
            
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
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
         
        }

        public void UpdateInfo(string firstName,string lastName,string phoneNumber, string address)
        {
            PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            personRepository.UpdateInformation(Id, address, firstName, lastName, phoneNumber);
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


        public bool MakePayment(decimal payment,string reason,DateTime time)
        {
            _balance -= payment;
            Transaction transaction = new Transaction(payment, "Payment", time, reason);
            _transactions.Add(transaction);
            //reason , a
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));
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

        public void Delete()
        {
            //set is Member to null, go back to the member look up
            PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            personRepository.UpdateMembership(Id);


        }
        public PersonView(Person person)
        {
            //same object
           // _person = person;
            _firstname = person.FirstName;
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


            //GetMyGroups();
            //GetOtherGroups();
            //GetOtherEvents();
            // GetMyEvents();
            //GetTransactions();
            // CalcBalance();
            //initialize groups and ......

            //List<Event> events = new List<Event>();
            /*for (int i = 0; i < 5; i++)
            {
                Event even = new Event(i, $"name{i}", 3, "description", " organizer", DateTime.Now, 3.5m);
                OtherEvents.Add(even);

            }
            /*
            for (int i = 5; i < 10; i++)
            {
                Event even = new Event(i, $"name{i}", 3, "description", " organizer", DateTime.Now, 3.5m);
                OtherEvents.Add(even);

            }*/


        }

        public PersonView(string firstname,string lastname, string address, string phonenumber)
        {
            _firstname = firstname;
            LastName = lastname;
            Address = address;
            PhoneNumber = phonenumber;

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

        private bool validphone()
        {
            
            string pattern = @"^\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{4}$";

            Regex regex = new Regex(pattern);
          
            Match match = regex.Match(PhoneNumber);

            return match.Success;
        }

        public bool Finalize => _firstname.Length > 0 && LastName.Length > 0 && Address.Length > 0 && validphone();


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
            _myevents.Clear();
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
                Transaction transaction = new Transaction( 3.5m + i, "Payment", DateTime.Now, "event");
                _transactions.Add(transaction);
            }
        }
    }
}
