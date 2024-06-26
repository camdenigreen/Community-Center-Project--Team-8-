﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DatabaseData;

namespace Community_Center_Project__Team_8_
{
    public class UpdatePersonView:INotifyPropertyChanged
    {
        public int Id;
        public UpdatePersonView(PersonView person)
        {
            Id = person.Id;
            _firstname = person.FirstName;
            _lastname = person.LastName;
            _address = person.Address;
            _number = person.PhoneNumber;

          //  PersonRepository repository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
           // repository.UpdateInformation(Id, _address, _firstname, _lastname, _number);

        }
        public UpdatePersonView(string firstname, string lastname, string address, string phonenumber)
        {
            _firstname = firstname;
            LastName = lastname;
            Address = address;
            PhoneNumber = phonenumber;

        }
        public UpdatePersonView()
        {
          
        }
        private bool validphone()
        {
            string pattern = @"^\(\d{3}\) \d{7}";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(PhoneNumber);

            return match.Success && _number.Length==13;
        }
        private string _firstname="";

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName{get
            {
                return _firstname;
            }

            set
            {
                _firstname = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));
            }
        }

        private string _lastname="";

        public string LastName
        {
            get
            {
                return _lastname;
            }

            set
            {
                _lastname = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));
            }
        }

        private string _address="";

        public string Address
        {
            get
            {
                return _address; ;
            }

            set
            {
                _address = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));
            }
        }
        private string _number="";

        public string PhoneNumber
        {
            get
            {
                return _number;
            }

            set
            {
                //validate phone number?set of correct codes.
                _number = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));

            }
        }

       
        public bool Finalize => _firstname.Length > 0 && _lastname.Length > 0 && _address.Length > 0 && validphone();

        public bool UpdateInfo()
        {
            //run the queries;
            //if unsuccessful, show failed-person already exists, 
            //if successful, show person updateed
            //take this information back to the person view
            return true;
        }
    }
}
