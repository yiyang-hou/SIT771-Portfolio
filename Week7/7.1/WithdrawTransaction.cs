using System;
using SplashKitSDK;

public class WithdrawTransaction : Transaction
{
    private Account _account;
    private bool _success = false;
    public override bool Success
    {
        get 
        {
            return _success;
        }
    }

    public WithdrawTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Withdraw(_amount);
    }

    public override void Rollback()
    {
        base.Rollback();
        _account.Deposit(_amount);
    }

    public override void Print()
    {
        Console.Write (DateStamp);
        if( Success )
        {
            Console.Write($"*${_amount} was SUCCESSFULLY withdrawed from {_account.Name}'s account.");
        }
        else
        {
            Console.Write("*This Withdraw transaction was FAILED!");
        }

        if( Reversed )
        {
            Console.WriteLine("|The transaction was rolled back.");
        }
        else
        {
            Console.WriteLine("|The transaction was not rolled back.");
        }

    }

    
}