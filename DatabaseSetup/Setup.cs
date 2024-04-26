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

        public void RebuildDatabase()
        {
            RebuildTables();
            PopulateTables();
        }

        public void RebuildTables()
        {
            string setupScript = File.ReadAllText(@"../../Tables.sql");

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
            // Considering constructing PeopleGroups, EventAttendance, Charges, and Payments
            // based on values in People, Groups, and Events rather than having a base sql script.
            // Alternatively just use a base sql script.

            string populatePeopleScript = File.ReadAllText(@"../../Data/People.People.sql");

            string populateGroupsScript = File.ReadAllText(@"../../Data/People.Groups.sql");

            // string populatePeopleGroupsScript = File.ReadAllText(@"../../Data/People.PeopleGroups.sql");

            string populateEventsScript = File.ReadAllText(@"../../Data/Events.Events.sql");

            // string populateEventAttendanceScript = File.ReadAllText(@"../../Data/Events.EventAttendance.sql");

            // string populatePaymentsScript = File.ReadAllText(@"../../Data/People.Payments.sql");

            // string populateChargesScript = File.ReadAllText(@"../../Data/People.Charges.sql");

            using (TransactionScope transaction = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    ExecuteScript(populatePeopleScript, connection);
                    ExecuteScript(populateGroupsScript, connection);
                    // ExecuteScript(populatePeopleGroupsScript, connection);
                    ExecuteScript(populateEventsScript, connection);
                    // ExecuteScript(populateEventAttendanceScript, connection);
                    // ExecuteScript(populatePaymentsScript, connection);
                    // ExecuteScript(populateChargesScript, connection);

                    transaction.Complete();
                }
            }
        }

        private void ExecuteScript(string script, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(script, connection))
            {
                command.CommandType = CommandType.Text;

                command.ExecuteNonQuery();
            }
        }
    }
}
