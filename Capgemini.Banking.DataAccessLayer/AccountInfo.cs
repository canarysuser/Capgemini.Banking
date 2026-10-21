using Capgemini.Banking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Banking.DataAccessLayer
{
    public class AccountInfo
    {
        private int _accountId; 
        private string _holderName;
        //CTRL + . can also be used to re-factor the code and generate 
        //properties
        private AccountType _accountType;
        private double _balance;

        // Method expression syntax => shortcut for single line statements 
        public int AccountId {
            get { return _accountId; } 
            set => _accountId = value; 
        }
        public string HolderName { 
            get => _holderName;
            set { _holderName = value; }
        }

        public AccountType AccountType { get => _accountType; set => _accountType = value; }
        public double Balance { get => _balance; set => _balance = value; }

        //Properties for all the fields 
        //Write 2 constructors. 
        //First constructor takes no arguments and initialize the default 
        //Second constructor takes 4 arguments and initializes the fields. 
        public AccountInfo(int id, string name, AccountType type, double amount)
        {
            _accountId = id;
            _holderName = name;
            _accountType = type;
            _balance= amount;
        }

    }
}
