using DataAccess;
using DataAccess.DataDelegates;
using DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DataDelegates
{
    public class FetchPersonDataDelegate : DataReaderDelegate<Person>
    {
        private readonly int _personId;

        public FetchPersonDataDelegate(int personId)
            : base("Person.FetchPerson")
        {
            _personId = personId;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            SqlParameter parameter = command.Parameters.AddWithValue("PersonID", _personId);
        }

        public override Person Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException(_personId.ToString());
            }

            return new Person(
                _personId,
                reader.GetString("FirstName"),
                reader.GetString("LastName"),
                reader.GetString("Address"),
                reader.GetString("PhoneNumber")
                );
                //reader.GetByte("IsMember"));
        }
    }
}
