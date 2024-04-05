using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Command
    {
        private readonly SqlCommand _command;

        public Command(SqlCommand command)
        {
            _command = command;
        }

        public SqlParameterCollection Parameters => _command.Parameters;

        public CommandType CommandType
        {
            get => _command.CommandType;

            set
            {
                _command.CommandType = value;
            }
        }
    }
}
