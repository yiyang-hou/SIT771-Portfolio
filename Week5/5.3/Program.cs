using System;
using SplashKitSDK;

public enum MenuOption
{
    Withdraw,
    Deposit,
    Print,
    Transfer,
    NewAccount,
    Quit
}
public class Program
{
    public static void Main()
    {
        Bank bank = new Bank();
        MenuOption userSelection;
       do
       {
            userSelection = ReadUserOption();
            switch(userSelection)
            {
                case MenuOption.Withdraw:
                DoWithdraw(bank);
                break;

                case MenuOption.Deposit:
                DoDeposit(bank);
                break;

                case MenuOption.Print:
                DoPrint(bank);
                break;

                case MenuOption.Transfer:
                DoTransfer(bank);
                break;

                case MenuOption.NewAccount:
                DoNewAccount(bank);
                break;

                case MenuOption.Quit:
                Console.WriteLine("QUIT!");
                break;
            }
       }
       while( userSelection != MenuOption.Quit);

    }

    public static MenuOption ReadUserOption()
    {
        int usersOption = 0;
        
        do
        {
            Console.WriteLine("*****Menu***** \n--------------------\n1. ---Withdraw---\n2. ---Deposit---\n3. ---Print---\n4. ---Transfer---\n5. ---New Account---\n6. ---Quit---\n--------------------");
            Console.Write("What would you like to do today: ");
            string userInput = Console.ReadLine();
            try{
                usersOption = Convert.ToInt32(userInput);
                if (usersOption < 1 || usersOption > 6)
                {
                    Console.WriteLine("Invalid Input, please try again!\n");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}\n");
                usersOption = -1;
            }
        }
        while(usersOption < 1 || usersOption > 6);
        return (MenuOption)(usersOption - 1);
    }

    
    public static void DoWithdraw(Bank toBank)
    {   
        Account toAccount = FindAccount(toBank);
        if ( toAccount == null) return;
        decimal withdrawAmount = 0;
        Console.Write("How much would you like to WITHDRAW? Please enter: $");
        string userWithdraw = Console.ReadLine();
        try
        {   
            withdrawAmount = Convert.ToDecimal(userWithdraw);
            WithdrawTransaction withdrawTransaction = new WithdrawTransaction(toAccount, withdrawAmount);
            toBank.ExecuteTransaction(withdrawTransaction);
            withdrawTransaction.Print();
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}\n");
        }
    }

    public static void DoDeposit(Bank toBank)
    {
        Account toAccount = FindAccount(toBank);
        if ( toAccount == null ) return;
        decimal depositAmount = 0;
        Console.Write("How much would you like to DEPOSIT? Please enter: $");
        string userDeposit = Console.ReadLine();
        try
        {
            depositAmount = Convert.ToDecimal(userDeposit);
            DepositTransaction depositTransaction = new DepositTransaction(toAccount, depositAmount);
            toBank.ExecuteTransaction(depositTransaction);
            depositTransaction.Print();
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}\n");
        }   
    }

    public static void DoPrint(Bank bank)
    {
        Account account = FindAccount( bank );
        if( account == null ) return;
        account.Print();
    }

    public static void DoTransfer(Bank bank)
    {
        Account fromAccount = FindAccount (bank);
        Account toAccount = FindAccount (bank);
        if (fromAccount == null || toAccount == null) return;
        decimal transferAmount = 0;
        Console.Write($"How much would you like to TRANSFER from {fromAccount.Name}'s account to {toAccount.Name}'s account? Please enter: $");
        string userTransfer = Console.ReadLine();
        try
        {
            transferAmount = Convert.ToDecimal(userTransfer);
            TransferTransaction transferTransaction = new TransferTransaction(fromAccount, toAccount, transferAmount);
            bank.ExecuteTransaction(transferTransaction);
            transferTransaction.Print();
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}\n");
        }   
    }

    public static void DoNewAccount( Bank bank )
    {
        decimal startingBalance = 0;
        Console.Write("Enter the name for the new account: ");
        string name = Console.ReadLine();
        Console.Write("Enter the starting balance for the new account: ");
        try
        {
            startingBalance = decimal.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Please enter a valid decimal number");
        }

        Account account = new Account(name, startingBalance);
        bank.AddAccount( account );
        Console.WriteLine("New account created.");
    }
    
    private static Account FindAccount( Bank fromBank )
    {
        Console.Write("Enter account name: ");
        string name = Console.ReadLine();
        Account result = fromBank.GetAccount(name);

        if ( result == null )
        {
            Console.WriteLine($"No account found with the name {name}");
        }

        return result;
    }
}
