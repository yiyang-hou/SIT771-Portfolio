using System;
using SplashKitSDK;

public enum MenuOption
{
    Withdraw,
    Deposit,
    Print,
    Quit
}
public class Program
{
    public static void Main()
    {
        Account YiyangsAcount = new Account("Yiyang Hou", 10000);
        MenuOption userSelection;
       do
       {
            userSelection = ReadUserOption();
            switch(userSelection)
            {
                case MenuOption.Withdraw:
                DoWithdraw(YiyangsAcount);
                break;

                case MenuOption.Deposit:
                DoDeposit(YiyangsAcount);
                break;

                case MenuOption.Print:
                DoPrint(YiyangsAcount);
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
            Console.WriteLine("*****Menu***** \n--------------------\n1. ---Withdraw---\n2. ---Deposit---\n3. ---Print---\n4. ---Quit---\n--------------------");
            Console.Write("What would you like to do today: ");
            string userInput = Console.ReadLine();
            try{
                usersOption = Convert.ToInt32(userInput);
                if (usersOption < 1 || usersOption > 4)
                {
                    Console.WriteLine("Invalid Input, please try again!\n");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"{userInput} is not a number, Please enter a number!\n");
                usersOption = -1;
            }
        }
        while(usersOption < 1 || usersOption > 4);
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
            bool successfulness = account.Withdraw(withdrawAmount);
            if(successfulness == true)
            {
                Console.WriteLine("Yay! Withdrawal SUCCEEDED!\n");
            }
            else
            {
                Console.WriteLine("Boo-boo! Withdrawal FAILED!\n");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"{userWithdraw} is not decimal number!\n");
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
            bool successfulness = account.Deposit(depositAmount);
            if(successfulness == true)
            {
                Console.WriteLine("Yay! Deposit SUCCEEDED!\n");
            }
            else
            {
                Console.WriteLine("Boo-boo! Deposit FAILED!\n");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"{userDeposit} is not decimal number!\n");
        }
    }

    public static void DoPrint(Account account)
    {
        account.Print();
    }
}
