using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.IO;

namespace DatabaseSetup
{
    public class Setup
    {
        private readonly string _connectionString;

        public Setup(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void RebuildTables()
        {
            string setupScript = File.ReadAllText("../../Tables.sql");

            using (TransactionScope transaction = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(setupScript, connection))
                    {
                        command.CommandType = CommandType.Text;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();
                    }
                }
            }
        }

        public void PopulateTables()
        {

        }
    }
}
