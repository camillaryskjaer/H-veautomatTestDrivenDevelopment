using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HæveautomatTestDrivenDevelopment
{
    HVad bruger du denne klasse til??
    public class Mockdata
    {
        public static List<Account> accounts = new List<Account>()
        {
            new Account("1643", 1000),
            new Account("7834", 0),
            new Account("0000", 1634523),
            new Account("1234", 86346)
        };

        public static void AddAccountToList(Account newAccount, List<Account> accounts)
        {
            accounts.Add(newAccount);
        }
    }
}
