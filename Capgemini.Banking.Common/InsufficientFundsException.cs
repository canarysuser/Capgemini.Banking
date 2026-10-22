using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Banking.Common
{
    public class InsufficientFundsException : Exception
    {
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomMessage { get; private set; } = ""; 
        public double Amount { get; set; }

        public InsufficientFundsException(int accountId, double amount)
            :this("Insufficient Funds", accountId, amount)
        {
            
        }
        public InsufficientFundsException(string message, int accountId, double amount) : base(message)
        {
            AccountId = accountId; TransactionDate=DateTime.Now;
            Amount = amount;
            CustomMessage = $"Failed withdrawal attempt on {AccountId} " +
                $"at {TransactionDate.ToString()} for {Amount:C}. " +
                "Reason: Insufficient Funds.";
        }
    }
}
