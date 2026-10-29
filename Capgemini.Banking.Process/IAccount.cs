using Capgemini.Banking.Common;

namespace Capgemini.Banking.Process
{
    public interface IAccount
    {
        void Deposit(double amount);
        void FundTransfer(IAccount target, double amount);
        double GetBalance();
        string ToString();
        void Withdraw(double amount);
        //Declare the events 
        event TransactionDelegate DepositEvent;
        event TransactionDelegate WithdrawEvent;
        //
    }
}