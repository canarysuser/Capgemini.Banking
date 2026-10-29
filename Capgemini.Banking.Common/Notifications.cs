using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Banking.Common
{
    public class TransactionEventArgs : System.EventArgs
    {
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = "Deposit";//Withdraw
        public double Amount { get; set; }
        public double Balance { get; set; }

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            //Fluent API 
            sb.AppendFormat("A {0} transaction ", TransactionType)
                .AppendFormat(" for {0:C2}", Amount)
                .AppendFormat(" has occured on your Account {0}", AccountId)
                .AppendFormat(" on {0}", TransactionDate)
                .AppendFormat("\nCurrent Balance is: {0}\n", Balance);
            return sb.ToString();
        }
    }
    public delegate void TransactionDelegate(TransactionEventArgs e);
}
