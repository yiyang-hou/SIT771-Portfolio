using System;

public class TransferTransaction : Transaction
{
    private Account _toAccount;
    private Account _fromAccount;

    private DepositTransaction _theDeposit;
    private WithdrawTransaction _theWithdraw;
    public override bool Success
    {
        get 
        {
            return (_theDeposit.Success && _theWithdraw.Success);
        }
    }
    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
    {
        _fromAccount = fromAccount;
        _toAccount = toAccount;
        _theWithdraw = new WithdrawTransaction(fromAccount, amount);
        _theDeposit = new DepositTransaction(toAccount, amount);
    }

    public override void Execute()
    {
        base.Execute();
        _theWithdraw.Execute();
        if( _theWithdraw.Success )
        {
            _theDeposit.Execute();
        
            if( !_theDeposit.Success && _theDeposit.Executed)
            {
                _theWithdraw.Rollback();
            }
        }
    }

    public override void Rollback()
    {
        base.Rollback();
        if(_theWithdraw.Success)
        {
            _theWithdraw.Rollback();
        }
        if(_theDeposit.Success)
        {
            _theDeposit.Rollback();
        }
    }
    
    public override void Print()
    {
        Console.Write (DateStamp);
        if( Success )
        {
            Console.WriteLine($"*${_amount} was transferred from {_fromAccount.Name}'s account to {_toAccount.Name}'s account.");
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

        if( Reversed )
        {
            Console.WriteLine("|The transaction was rolled back.");
        }
        

    }
    
}