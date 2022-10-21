using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.DAO
{
    public class DataBase
    {
        private static string connectionString = @"Data Source=(LocalDb)\cours-dotnet-sogeti;Integrated Security=True";

        public static SqlConnection Connection { get => new SqlConnection(connectionString); }
    }
}
