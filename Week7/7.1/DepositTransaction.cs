using System;
using SplashKitSDK;

public class DepositTransaction : Transaction
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

    public DepositTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Deposit(_amount);
    }

    public override void Rollback()
    {
        base.Rollback();
        _account.Withdraw(_amount);
    }

    public override void Print()
    {   
        Console.Write (DateStamp);
        if( Success )
        {
            Console.Write($"*${_amount} was SUCCESSFULLY deposited into {_account.Name}'s account.");
        }
        else
        {
            Console.Write("*This deposit transaction was FAILED!");
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