using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HæveautomatTestDrivenDevelopment.ATM
{
    public static class ATM
    {
        public static Account Login(string pincode)
        {
            Account output = new Account();

            if (pincode.Length != 4 || Regex.IsMatch(pincode, "[^0-9]"))
            {
                try
                {
                    throw new ArgumentException("Pincode format was incorrect");
                }
                catch (ArgumentException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2000);
                }
            }
            else
            {
                foreach (Account account in Mockdata.accounts)
                {
                    if (account.Pincode == pincode)
                    {
                        output = account;
                        break;
                    }
                }
            }

            return output;
        }

        public static bool WithdrawMoney(Account account, double withdrawMoney)
        {
            bool output = false;
            if (account.Balance < withdrawMoney)
            {
                throw new ArgumentException("Balance too low");
            }
            else if (withdrawMoney <= 0)
            {
                throw new ArgumentException("Cannot withdraw 0 or less");
            }
            else
            {
                account.WithdrawMoney(withdrawMoney);
                output = true;
            }
            return output;
        }

        public static bool DepositMoney(Account account, double depositMoney)
        {
            bool output = false;
            if (depositMoney <= 0)
            {
                throw new ArgumentException("Cannot insert 0 or less");
            }
            else
            {
                account.DepositMoney(depositMoney);
                output = true;
            }
            return output;
        }

        public static Account GenerateAccount()
        {
            Account newAccount = new Account();
            bool run = true;
            while (run == true)
            {
                newAccount = new Account(new Random().Next(0, 10000).ToString("D4"), 0);
                foreach (Account account in Mockdata.accounts)
                {
                    if (account.Pincode == newAccount.Pincode)
                    {
                        run = true;
                        break;
                    }
                    else
                    {
                        run = false;
                    }
                }
            }
            return newAccount;
        }

        public static void AddAccountToList(Account newAccount, List<Account> accounts)
        {
            if (string.IsNullOrWhiteSpace(newAccount.Pincode))
            {
                throw new ArgumentException("Invalid parameter: Pincode");
            }
            else
            {
                Mockdata.AddAccountToList(newAccount, accounts);
            }
        }
    }
}
