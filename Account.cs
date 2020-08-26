using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HæveautomatTestDrivenDevelopment
{
    public class Account
    {
        private string pincode;
        public string Pincode
        {
            get { return pincode; }
        }
        private double balance;

        public double Balance
        {
            get{ return balance; }
        }

        public Account()
        {

        }

        public Account(string pincode, double balance)
        {
            this.pincode = pincode;
            this.balance = balance;
        }

        public void DepositMoney(double DepositMoney)
        {
            balance += DepositMoney;
        }

        public void WithdrawMoney(double withdrawMoney)
        {
            balance -= withdrawMoney;
        }
    }
}
