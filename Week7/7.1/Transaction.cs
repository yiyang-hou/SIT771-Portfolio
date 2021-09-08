using System;
using SplashKitSDK;
public abstract class Transaction
{
    protected decimal _amount;
    private bool _executed = false;
    private bool _reversed = false;
    private DateTime _dateStamp;
    public abstract bool Success
    {
        get;
    }
    public bool Executed
    {
        get
        {
            return _executed;
        }
    }
    public bool Reversed
    {
        get
        {
            return _reversed;
        }
    }
    public DateTime DateStamp
    {
        get
        {
            return _dateStamp;
        }
    }
    public Transaction( decimal amount )
    {
        _amount = amount;
    }
    public abstract void Print();
    public virtual void Execute()
    {
         if( _executed )
        {
            throw new Exception("Cannot execute this transaction as it has already been exected.");
        }

        _executed = true;
        _dateStamp = DateTime.Now;
    }
    public virtual void Rollback()
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
        _dateStamp = DateTime.Now;
    }
}