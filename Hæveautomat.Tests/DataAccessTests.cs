using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HæveautomatTestDrivenDevelopment;
using Xunit;
using System.IO;
using HæveautomatTestDrivenDevelopment.ATM;

namespace Hæveautomat.Tests
{
    public class DataAccessTests
    {
        //checks that adding an account works
        [Fact]
        public void AddAccountToList_ShouldWork()
        {
            Account newAccount = new Account("1111", 1234);
            List<Account> accounts = new List<Account>();

            ATM.AddAccountToList(newAccount, accounts);

            Assert.True(accounts.Count == 1);
            Assert.Contains(newAccount, accounts);
        }

        //checks that a account without a pincode doesnt work
        [Theory]
        [InlineData("", 0)]
        public void AddAccountToList_ShouldNotWork(string pincode, double balance)
        {
            Account newAccount = new Account(pincode, balance);
            List<Account> accounts = new List<Account>();

            Assert.Throws<ArgumentException>(() => ATM.AddAccountToList(newAccount, accounts));
        }

        //checks that withdraw money works
        [Theory]
        [InlineData("1234", 1000, 500)]
        [InlineData("1234", 1000, 99.9)]
        public void WithdrawMoney_ShouldWork(string pincode, double balance, double withdrawMoney)
        {
            Account newAccount = new Account(pincode, balance);

            Assert.True(ATM.WithdrawMoney(newAccount, withdrawMoney));
        }

        //checks that withdraw money with bad input doesnt work
        [Theory]
        [InlineData("1234", 1000, 1500)]
        [InlineData("1234", 1000, -10)]
        [InlineData("1234", 1000, 0)]
        public void WithdrawMoney_ShouldNotWork(string pincode, double balance, double withdrawMoney)
        {
            Account newAccount = new Account(pincode, balance);

            Assert.Throws<ArgumentException>(() => ATM.WithdrawMoney(newAccount, withdrawMoney));
        }

        //checks that insert money works
        [Theory]
        [InlineData("1234", 1000, 500)]
        [InlineData("1234", 1000, 1.1)]
        public void InsertMoney_ShouldWork(string pincode, double balance, double insertMoney)
        {
            Account newAccount = new Account(pincode, balance);

            Assert.True(ATM.DepositMoney(newAccount, insertMoney));
        }

        //checks that insert money with bad input doesnt work
        [Theory]
        [InlineData("1234", 1000, -10)]
        [InlineData("1234", 1000, 0)]
        public void InsertMoney_ShouldNotWork(string pincode, double balance, double insertMoney)
        {
            Account newAccount = new Account(pincode, balance);

            Assert.Throws<ArgumentException>(() => ATM.DepositMoney(newAccount, insertMoney));
        }

        //checks that the automated account generator works
        [Fact]
        public void GenerateAccount_ShouldWork()
        {
            Account newAccount = ATM.GenerateAccount();
            bool works = true;

            foreach (Account account in Mockdata.accounts)
            {
                if (account.Pincode == newAccount.Pincode)
                {
                    works = false;
                    break;
                }
            }

            Assert.True(works);
        }
    }
}
