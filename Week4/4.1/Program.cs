using System;
using SplashKitSDK;

public enum MenuOption
{
    Withdraw,
    Deposit,
    Print,
    Transfer,
    Quit
}
public class Program
{
    public static void Main()
    {
        Account yiyangsAccount = new Account("Yiyang", 10000);
        Account jakesAccount = new Account("Jake", 50000);
        MenuOption userSelection;
       do
       {
            userSelection = ReadUserOption();
            switch(userSelection)
            {
                case MenuOption.Withdraw:
                DoWithdraw(yiyangsAccount);
                break;

                case MenuOption.Deposit:
                DoDeposit(yiyangsAccount);
                break;

                case MenuOption.Print:
                DoPrint(yiyangsAccount, jakesAccount);
                break;

                case MenuOption.Transfer:
                DoTransfer(jakesAccount, yiyangsAccount);
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
            Console.WriteLine("*****Menu***** \n--------------------\n1. ---Withdraw---\n2. ---Deposit---\n3. ---Print---\n4. ---Transfer---\n5. ---Quit---\n--------------------");
            Console.Write("What would you like to do today: ");
            string userInput = Console.ReadLine();
            try{
                usersOption = Convert.ToInt32(userInput);
                if (usersOption < 1 || usersOption > 5)
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
        while(usersOption < 1 || usersOption > 5);
        return (MenuOption)(usersOption - 1);
    }

    
    public static void DoWithdraw(Account account)
    {   
        decimal withdrawAmount = 0;
        Console.Write("How much would you like to WITHDRAW? Please enter: $");
        string userWithdraw = Console.ReadLine();
        try
        {   
            withdrawAmount = Convert.ToDecimal(userWithdraw);
            WithdrawTransaction withdrawTransaction = new WithdrawTransaction(account, withdrawAmount);
            withdrawTransaction.Execute();
            withdrawTransaction.Print();
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}\n");
        }
    }

    public static void DoDeposit(Account account)
    {
        decimal depositAmount = 0;
        Console.Write("How much would you like to DEPOSIT? Please enter: $");
        string userDeposit = Console.ReadLine();
        try
        {
            depositAmount = Convert.ToDecimal(userDeposit);
            DepositTransaction depositTransaction = new DepositTransaction(account, depositAmount);
            depositTransaction.Execute();
            depositTransaction.Print();
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}\n");
        }   
    }

    public static void DoPrint(Account account, Account account1)
    {
        account.Print();
        account1.Print();
    }

    public static void DoTransfer(Account fromAccount, Account toAccount)
    {
        decimal transferAmount = 0;
        Console.Write($"How much would you like to TRANSFER from {fromAccount.Name}'s account to {toAccount.Name}'s account? Please enter: $");
        string userTransfer = Console.ReadLine();
        try
        {
            transferAmount = Convert.ToDecimal(userTransfer);
            TransferTransaction transferTransaction = new TransferTransaction(fromAccount, toAccount, transferAmount);
            transferTransaction.Execute();
            transferTransaction.Print();
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message}\n");
        }   
    }
}
