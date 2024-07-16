using FinanceManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using FinanceManagement.Account;


namespace FinanceManagement
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            var bankMenu = new BankMenu();
            
           
            

            
            var AccountManagment = new AccountManagement();

   
            do
            {
                Console.WriteLine("1 - Login \n2 - Create an account");
                int input = Convert.ToInt32(Console.ReadLine());


                switch(input)
                {
                    case 1:
                        AccountManagment.CreateAccount();
                        break;

                    case 2:
                        Console.WriteLine("---Login---");
                        Console.WriteLine("Username");
                        string username = Console.ReadLine();
                        Console.WriteLine("Password");
                        string password = Console.ReadLine();
                        
                        AccountManagment.Login(username,password);
                        
                        
                        break;





                }




            }while (true);


        }
    }
}
