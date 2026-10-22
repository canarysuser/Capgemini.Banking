using Capgemini.Banking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Banking.Process
{
    internal class Savings : Account
    {
        //constructor and invoke the base class constructor 
        public Savings(int id, string name, AccountType type, double amount )
            : base( id, name, type, amount)
        {

        }
        //Refined Behaviour
        public override void Withdraw(double amount)
        {
            if(_info.Balance - amount > 999)
            {
                _info.Balance -= amount;
            } else
            {
                //TODO: Complete the else part of Savings.
                throw new InsufficientFundsException(
                    accountId: _info.AccountId,
                    amount: amount); 
            }
        }
    }
}
