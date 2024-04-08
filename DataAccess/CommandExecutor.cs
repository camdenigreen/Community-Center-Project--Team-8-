using DataAccess.IDataDelegates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess
{
    public class CommandExecutor
    {
        private readonly string _connectionString;

        public CommandExecutor(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public void ExecuteNonQuery(IDataDelegate dataDelegate)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = GenerateCommand(dataDelegate.ProcedureName, connection))
                    {
                        dataDelegate.PrepareCommand(new Command(command));

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();
                    }
                }
            }
        }

        public T ExecuteNonQuery<T> (INonQueryDataDelegate<T> dataDelegate)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = GenerateCommand(dataDelegate.ProcedureName, connection))
                    {
                        Command commandWrapper = new Command(command);

                        dataDelegate.PrepareCommand(commandWrapper);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        return dataDelegate.Translate(commandWrapper);
                    }
                }
            }
        }

        public T ExecuteReader<T>(IDataReaderDelegate<T> dataDelegate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = GenerateCommand(dataDelegate.ProcedureName, connection))
                {
                    Command commandWrapper = new Command(command);

                    dataDelegate.PrepareCommand(commandWrapper);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    return dataDelegate.Translate(commandWrapper, new DataRowReader(reader));
                }
            }
        }

        public SqlCommand GenerateCommand(string procedureName, SqlConnection connection)
        {
            return new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
        }
    }
}
