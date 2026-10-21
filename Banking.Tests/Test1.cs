using Capgemini.Banking.Process;

namespace Banking.Tests
{
    [TestClass] // Test Suite 
    public sealed class AccountTest
    {
        [TestMethod] //=> Test Case 
        public void TestDepositMethodWithValidValues()
        {
            //Arrange 
            Account acc = AccountFactory.Create(
                id: 100, 
                name: "Sample", 
                type: Capgemini.Banking.Common.AccountType.Savings,
                balance: 5000);
            double expectedBalance = acc.GetBalance() + 5000.0;
            double actualBalance = 0;

            //Act - invoke the Deposit function 
            acc.Deposit(5000); 
            actualBalance = acc.GetBalance();

            //Assert 
            Assert.AreEqual(expectedBalance, actualBalance);


        }
        [TestMethod]
        public void TestFundTransferWithValidValues()
        {
            Account acc1 = /*new Account*/AccountFactory.Create(
               id: 100,
               name: "Sample",
               type: Capgemini.Banking.Common.AccountType.Savings,
               balance: 5000);
            Account acc2 = AccountFactory.Create(
               id: 100,
               name: "Sample",
               type: Capgemini.Banking.Common.AccountType.Savings,
               balance: 5000);
            double amountToTransfer = 1000;
            double expectedBalanceInFirstAccount = acc1.GetBalance() - amountToTransfer;
            double expectedBalanceInSecondAccount = acc2.GetBalance() + amountToTransfer;

            acc1.FundTransfer(acc2, amountToTransfer); 
            double actualBalanceInFirstAccount=acc1.GetBalance();
            double actualBalanceInSecondAccount=acc2.GetBalance();

            Assert.AreEqual(expectedBalanceInFirstAccount, actualBalanceInFirstAccount);
            Assert.AreEqual(expectedBalanceInSecondAccount, actualBalanceInSecondAccount);

        }

        [TestMethod]
        public void TestAccountCreationWithInvalidValues()
        {
            //Arrange 
            Account acc1 = AccountFactory.Create(
               id: 100,
               name: "Sample",
               type: Capgemini.Banking.Common.AccountType.Savings,
               balance: 3000);

            Assert.IsNull(acc1); 
            //Assert.Fail();

        }
        [TestMethod]
        public void TestSavingsAccountWithdrawRuleWithInvalidValues()
        {
            Account acc = AccountFactory.Create(
               id: 100,
               name: "Sample",
               type: Capgemini.Banking.Common.AccountType.Savings,
               balance: 5000);
            double expectedBalance = acc.GetBalance();

            acc.Withdraw(5000); 
            double actualBalance = acc.GetBalance();
            Assert.AreEqual(expectedBalance, actualBalance);
        }
        [TestMethod]
        public void TestSavingsAccountWithdrawRuleWithValidValues()
        {
            Account acc = AccountFactory.Create(
               id: 100,
               name: "Sample",
               type: Capgemini.Banking.Common.AccountType.Savings,
               balance: 5000);
            double expectedBalance = acc.GetBalance() - 2000; 

            acc.Withdraw(2000);
            double actualBalance = acc.GetBalance();
            Assert.AreEqual(expectedBalance, actualBalance);
        }
    }
}
