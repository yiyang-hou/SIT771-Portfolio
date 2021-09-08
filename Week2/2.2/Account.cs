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
    public void Deposit(decimal amountToAdd)
    {
        _balance += amountToAdd;
    }

    //Withdraw mathod
    public void Wiithdraw(decimal amountToSubtract)
    {
        _balance -= amountToSubtract;
    }

    //Read name property
    public string Name
    {
        get { return _name; }
    }

    //Print method
    public void Print()
    {
        Console.WriteLine($"Name: {_name} Balance: {_balance}");
    }
}