using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Center_Project__Team_8_
{
    public class UpdatePersonView
    {
        public int Id;
        public UpdatePersonView(int id)
        {
            Id = id;
        }
        public string FirstName{get;set;}

        public string LastName { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        public bool Finalize => FirstName.Length > 0 && LastName.Length > 0 && Address.Length > 0 && PhoneNumber.Length > 0;

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
