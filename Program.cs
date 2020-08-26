using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HæveautomatTestDrivenDevelopment
{
    class Program
    {
        private static bool loop = true;
        private static string input;
        private static string savedInput;
        static void Main(string[] args)
        {
            while (loop == true)
            {
                Console.Clear();
                StartMenuGui();

                switch (Convert.ToInt32(savedInput))
                {
                    case 1:
                    {
                        LoginGui();
                        break;
                    }
                    case 2:
                    {
                        Account newAccount = ATM.ATM.GenerateAccount();
                        ATM.ATM.AddAccountToList(newAccount, Mockdata.accounts);
                        Console.WriteLine("New account has been made\nPincode: {0}\n\nPress ( ENTER ) to continue", newAccount.Pincode);
                        Console.ReadKey(true);
                        break;
                    }
                    case 3:
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            }
        }

        //gui method to display start menu, which returns the user input
        private static void StartMenuGui()
        {
            Console.WriteLine("1. Login\n2. Make new account\n3. Exit");
            while (loop == true)
            {
                input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3")
                {
                    savedInput = input;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("1. Login\n2. Make new account\n3. Exit");
                    Console.WriteLine("Wrong input, try again");
                }
            }
            Console.Clear();
        }

        private static void LoginGui()
        {
            Console.Write("Pincode: ");
            while (loop == true)
            {
                input = Console.ReadLine();
                Account account = ATM.ATM.Login(input);
                if (account.Pincode == input)
                {
                    Console.Clear();
                    LoggedinGui(account);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input, try again");
                    Console.Write("Pincode: ");
                }
            }
        }

        private static void LoggedinGui(Account account)
        {
            while (loop == true)
            {
                LoggedinMenuGui(account);
                switch (Convert.ToInt32(savedInput))
                {
                    case 1:
                    {
                        Console.Write("Withdraw amount: ");
                        while (loop == true)
                        {
                            input = Console.ReadLine();
                            if (Regex.IsMatch(input, "[^1234567890.]"))
                            {
                                Console.Clear();
                                Console.WriteLine("Input value is not a number and/or contains comma");
                                Console.Write("Withdraw amount: ");
                            }
                            else
                            {
                                break;
                            }
                        }

                        try
                        {
                            ATM.ATM.WithdrawMoney(account, Convert.ToDouble(input));
                            Console.WriteLine("New balance: {0}", account.Balance);
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            Thread.Sleep(2000);
                        }
                        Thread.Sleep(2000);
                        break;
                    }
                    case 2:
                    {
                        Console.Write("Deposit amount: ");
                        while (loop == true)
                        {
                            input = Console.ReadLine();
                            if (Regex.IsMatch(input, "[^1234567890.]"))
                            {
                                Console.Clear();
                                Console.WriteLine("Input value is not a number and/or contains comma");
                                Console.Write("Deposit amount: ");
                            }
                            else
                            {
                                break;
                            }
                        }

                        try
                        {
                            ATM.ATM.DepositMoney(account, Convert.ToDouble(input));
                            Console.WriteLine("New balance: {0}", account.Balance);
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            Thread.Sleep(2000);
                        }
                        Thread.Sleep(2000);
                        break;
                    }
                    case 3:
                    {
                        break;
                    }
                }
                Console.Clear();
                if (savedInput == "3")
                {
                    break;
                }
            }
        }

        private static void LoggedinMenuGui(Account account)
        {
            Console.WriteLine("Balance: {0}", account.Balance);
            Console.WriteLine("1. Withdraw\n2. Deposit\n3. Exit to main menu");
            while (loop == true)
            {
                input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3")
                {
                    savedInput = input;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Balance: {0}", account.Balance);
                    Console.WriteLine("1. Withdraw\n2. Deposit\n3. Exit to main menu");
                    Console.WriteLine("Wrong input, try again");
                }
            }
        }
    }
}
