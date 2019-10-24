using System;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class StartUp
    {
        private static string connectionString = @"Server=PRETORIAN\SQLEXPRESS;Database=master;Integrated Security=true";
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
            }
        }
    }
}
