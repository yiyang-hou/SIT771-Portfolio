using System;

public class TransferTransaction
{
    private Account _toAccount;
    private Account _fromAccount;
    private decimal _amount;

    private DepositTransaction _theDeposit;
    private WithdrawTransaction _theWithdraw;
    private bool _executed = false;
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
            return (_theDeposit.Success && _theWithdraw.Success);
        }
    }
    public bool Reversed
    {
        get 
        {
            return _reversed;
        }
    }
    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
        _fromAccount = fromAccount;
        _toAccount = toAccount;
        _amount = amount;
        _theWithdraw = new WithdrawTransaction(fromAccount, amount);
        _theDeposit = new DepositTransaction(toAccount, amount);
    }

    public void Execute()
    {
        if(_executed)
        {
            throw new Exception("Cannot execute this transaction as it has already been exected.");
        }
        _theWithdraw.Execute();
        if( _theWithdraw.Success )
        {
            _theDeposit.Execute();
        
            if( !_theDeposit.Success && _theDeposit.Executed)
            {
                _theWithdraw.Rollback();
            }
        }
        _executed = true;
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
        if(_theWithdraw.Success)
        {
            _theWithdraw.Rollback();
        }
        if(_theDeposit.Success)
        {
            _theDeposit.Rollback();
        }
        
        _reversed = true;
    }
    
    public void Print()
    {
        if( Success )
        {
            Console.WriteLine($"*${_amount} was transferred from {_fromAccount.Name}'s Account to {_toAccount.Name}'s account.");
            Console.Write($"      ");
            _theWithdraw.Print();
            Console.Write($"      ");
            _theDeposit.Print();
        }
        else
        {
            Console.WriteLine("*This transaction was FAILED!");
            Console.Write($"      ");
            _theWithdraw.Print();
            Console.Write($"      ");
            _theDeposit.Print();
        }

        if( _reversed )
        {
            Console.WriteLine("|The transaction was rolled back.");
        }
        

    }
    
}