using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using FinanceManagement.Utilities;
using Npgsql;


namespace FinanceManagement.Account
{
    

    public class AccountManagement
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        
        private List<Account> accounts = new List<Account>();
        

        public void CreateAccount()
        {
            Account newAccount;
            string insertQuery = "INSERT INTO user_management.user_credentials(username,password)VALUES (@uA,@uP)";

            Console.WriteLine("---Account Creation---");
            Console.WriteLine("Username");
            string uA = Console.ReadLine();
            Console.WriteLine("Password");
            string uP = Console.ReadLine();

            using (var conn = DatabaseManager.GetConnection())
            {
                conn.Open();


                using (var cmd = new NpgsqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("uA", uA);
                    cmd.Parameters.AddWithValue("uP", uP);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected}Rows were inserted");

                    if (rowsAffected > 0)
                    {
                        
                    }

                }

            }

           
        }

        
        public bool Login(string username, string password)
        {
            
            string selectQuery =
                "SELECT id, username, password FROM user_management.user_credentials WHERE username = @username";

            try
            {
                using (var conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("username", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string storedUsername = reader.GetString(1);
                                string storedPassword = reader.GetString(2);

                                
                                if (password == storedPassword)
                                {
                                    Console.WriteLine($"Login successful. Welcome, {storedUsername}!");
                                    UserID = id;
                                    Username = storedUsername;
                                    
                                    var bankMenu = new BankMenu();
                                    bankMenu.DisplayMenu();
                                    return true;
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Invalid username or password.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
        
