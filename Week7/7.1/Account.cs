using System;


public class Account
{
    private decimal _balance;
    private string _name;

    //Constructor
    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;

    }

    //Deposit method
    public bool Deposit(decimal amountToDeposit)
    {
        if (amountToDeposit > 0)
        {
            _balance += amountToDeposit;
            return true;
        }
        else
        {
            Console.WriteLine("**WARNING**\nThe deposit amount must be a positive number!");
            return false;
        }
    }

    //Withdraw mathod
    public bool Withdraw(decimal amountToWithdraw)
    {
        if(amountToWithdraw > 0 && amountToWithdraw <= _balance )
        {
            _balance -= amountToWithdraw;
            return true;
        }
        else if (amountToWithdraw <= 0)
        {
            Console.WriteLine("**WARNING**\nThe withdraw amount must be a positive number!");
            return false;
        }
        else
        {
            Console.WriteLine("**WARNING**\nThe withdraw amount must not exceed your exiting funds!");
            return false;
        }
        
    }

    //Read name property
    public string Name
    {
        get { return _name; }
    }

    //Print method
    public void Print()
    {
        Console.WriteLine($"Account Name: {Name}\nBalance: {_balance}\n");
    }
}