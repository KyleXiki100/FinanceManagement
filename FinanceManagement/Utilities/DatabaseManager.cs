namespace FinanceManagement.Utilities
{
    using Npgsql;
    using System;

    public class DatabaseManager
    {
        private static readonly string connectionString = "Host=localhost;Username=postgres;Password=humat5400;Database=postgres";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

       
        }
    }


    