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

            string connectionString = string.Format(@"SERVER={0};DATABASE={1};INTEGRATED SECURITY=SSPI;", SERVER, DATABASE);

            Setup setupObject = new Setup(connectionString);

            setupObject.RebuildDatabase();
        }
    }
}
