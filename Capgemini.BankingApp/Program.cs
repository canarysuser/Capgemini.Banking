
using Capgemini.Banking.Common;
using Capgemini.Banking.Process;

int choice = 0;
do
{
    Console.Clear();
    Console.WriteLine("******************************************");
    Console.WriteLine("***********Application Menu **************");
    Console.WriteLine("***  1. Create New Account");
    Console.WriteLine("***	2. Deposit Amount ");
    Console.WriteLine("***	3. Withdraw Amount");
    Console.WriteLine("***	4. Transfer Funds ");
    Console.WriteLine("***	9. Quit ");
    Console.WriteLine("*** ");
    Console.Write("*** Your Choice:");
    choice = int.Parse(Console.ReadLine());
    Console.WriteLine("*******************************************");
    if(choice !=9)
    {
        IAccount acc = null!;
        switch(choice)
        {
            case 1:
                try
                {
                    AddNewAccount(); 
                } catch (InsufficientFundsException ex)
                {
                    Console.WriteLine(ex.CustomMessage);
                }
                break;
            case 2: Deposit(); break;
            case 3: Withdraw(); break;
        }
    }
} while (choice != 9);



static IAccount AddNewAccount()
{
    Console.Clear();
    Console.WriteLine("*************** Add New Account ************");
    Console.WriteLine();
    Console.Write("Enter Account ID: "); 
    int accountId = int.Parse(Console.ReadLine()!);
    Console.Write("Enter Account Holder Name: ");
    string holderName = Console.ReadLine();
    Console.Write("Account Type [1 for Savings, 2 for Current]: ");
    int accType = int.Parse(Console.ReadLine());
    AccountType type = (AccountType)accType;
    Console.Write("Opening Balance: "); 
    double balance = double.Parse(Console.ReadLine()!);
    Console.Write("\n\nSave Details [y/N]? "); 
    string yesNo = Console.ReadLine();
    IAccount acc=null!;
    if (yesNo.ToLower() == "y")
    {
        //try
        //{
            acc = AccountFactory.Create(accountId, holderName, type, balance);
        //}
        //catch (InsufficientFundsException ex)
        //{
        //}
    }
    return acc;
}

static void Deposit()
{
    ////

    try
    {
        IAccount acc = AddNewAccount();
        //Subscription being added here. 
        acc.DepositEvent += (e) => Console.WriteLine(e); 

        Console.Write("\nAmount to deposit: ");
        double amount = double.Parse(Console.ReadLine()!);
        acc.Deposit(amount);
    }
    catch (InsufficientFundsException ex)
    {
        Console.WriteLine(ex.CustomMessage);
    }
    finally
    {
        Console.WriteLine("Deposit operation completed.");
    }
    Console.WriteLine("\n\nPress a key to go back to Main Menu.");
    Console.ReadKey();
}

static void Withdraw()
{
    ////
    
    try
    {
        IAccount acc = AddNewAccount();
        //if (acc is not null)
        //{
            Console.Write("\nAmount to withdraw: ");
            double amount = double.Parse(Console.ReadLine()!);
            acc.Withdraw(amount);
        //} else
        //{
        //    Console.WriteLine("Account is not created.");
        //}
    }
    catch (InsufficientFundsException ex)
    {
        Console.WriteLine(ex.CustomMessage);
    }
    finally
    {
        Console.WriteLine("Withdraw operation completed.");
    }
    Console.WriteLine("\n\nPress a key to go back to Main Menu.");
    Console.ReadKey();
}
static void FundTransfer()
{
    try
    {
        IAccount acc1 = AddNewAccount();
        IAccount acc2 = AddNewAccount();
        
        Console.Write("\nAmount to Transfer: ");
        double amount = double.Parse(Console.ReadLine()!);
        acc1.FundTransfer(acc2, amount);
    }
    catch (InsufficientFundsException ex)
    {
        Console.WriteLine(ex.CustomMessage);
    }
    finally
    {
        Console.WriteLine("Withdraw operation completed.");
    }
    Console.WriteLine("\n\nPress a key to go back to Main Menu.");
    Console.ReadKey();
}
