using Capgemini.Banking.Common;
using Capgemini.Banking.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Banking.Process
{
    public abstract class Account
    {
        /*private*/ protected AccountInfo _info;

        public Account(int id, string name, AccountType type, double balance)
        {
            _info = new AccountInfo(id, name, type, balance);
        }
        ~Account()
        {
            _info = null!;
        }
        public void Deposit(double amount) { _info.Balance += amount; }
        public abstract void Withdraw(double amount);
        //{
            //_info.Balance -= amount;
            /*if (_info.AccountType == AccountType.Savings && (_info.Balance - amount > 999))
            {
                _info.Balance -= amount;
            } else if (_info.AccountType == AccountType.Current && (_info.Balance - amount > 4999))
            {
                _info.Balance -= amount;
            } else
            {
                //Do nothing.
            }*/
       // }
        public void FundTransfer(Account target, double amount)
        {
            this.Withdraw(amount);
            target.Deposit(amount);
        }
        public double GetBalance() => _info.Balance;
        //public double GetBalance() { return _info.Balance; } 

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //Create a string to output the data in the below format
            //Id: 001, Name: name, Type: Accounttype, Balance: $5,000.00
            sb.AppendFormat("Id: {0:000}, ", _info.AccountId);
            sb.AppendFormat("Name: {0}, ", _info.HolderName);
            sb.AppendFormat("Type: {0}, ", _info.AccountType.ToString());
            sb.AppendFormat("Balance: {0:C}, ", _info.Balance);
            return sb.ToString();
        }
    }
}
