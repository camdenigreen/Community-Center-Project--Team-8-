using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace DatabaseSetup
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string SERVER= @"(localdb)\MSSQLLocalDb";
            const string DATABASE = @"communitycenter";

            // DRIVER={{ODBC Driver 17 for SQL Server}};SERVER=(localdb)\\MSSQLLocalDb;DATABASE=WideWorldImporters;Trusted_Connection=yes

            string connectionString = string.Format(@"SERVER={0};DATABASE={1};INTEGRATED SECURITY=SSPI;Trusted_Connection=yes", SERVER, DATABASE);

            Setup setupObject = new Setup(connectionString);

            setupObject.RebuildTables();
        }
    }
}
