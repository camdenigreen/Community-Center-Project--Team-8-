using DataAccess;
using DataAccess.DataDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Sql.StoredProcedures
{
    public class UpdateLastNameDataDelegate : DataDelegate
    {
        private readonly int _personID;

        private readonly string _lastName;

        public UpdateLastNameDataDelegate(int personID, string lastName)
            : base("People.UpdateLastName")
        {
            _personID = personID;
            _lastName = lastName;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonID", _personID);
            command.Parameters.AddWithValue("LastName", _lastName);
        }
    }
}
