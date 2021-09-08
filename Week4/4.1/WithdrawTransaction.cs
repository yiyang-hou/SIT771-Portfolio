using System;
using SplashKitSDK;

public class WithdrawTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;

    public bool Executed
    {
        get 
        {
            return _executed;
        }
    }
    public bool Success
    {
        get 
        {
            return _success;
        }
    }
    public bool Reversed
    {
        get 
        {
            return _reversed;
        }
    }

    public WithdrawTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        if( _executed )
        {
            throw new Exception("Cannot execute this transaction as it has already been exected.");
        }

        _executed = true;
        _success = _account.Withdraw(_amount);
    }

    public void Rollback()
    {
        if( !_executed )
        {
            throw new Exception("Cannot rollback this transaction as it has not been executed.");
        }
        if( _reversed )
        {
            throw new Exception("Cannot rollback this transaction as it has already been reversed.");
        }
        _reversed = true;
        _account.Deposit(_amount);
    }

    public void Print()
    {
        if( _success )
        {
            Console.Write($"*${_amount} was SUCCESSFULLY withdrawed from {_account.Name}'s account.");
        }
        else
        {
            Console.Write("*This Withdraw transaction was FAILED!");
        }

        if( _reversed )
        {
            Console.WriteLine("|The transaction was rolled back.");
        }
        else
        {
            Console.WriteLine("|The transaction was not rolled back.");
        }

    }

    
}