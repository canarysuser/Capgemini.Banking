using Capgemini.Banking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Banking.Process
{
    public class AccountFactory
    {
        public static IAccount Create(int id, string name, 
            AccountType type, double balance)
        {
            Account acc = null!; 
            if(type==AccountType.Savings && balance > 4999)
            {
                acc = new /*Account*/ Savings(id, name, type, balance);
            } else if(type==AccountType.Current && balance > 9999)
            {
                acc = new Current(id, name, type, balance);
            } else
            {
                throw new InsufficientFundsException(id, balance); 
            }
                return acc!; 
        }
    }
}
