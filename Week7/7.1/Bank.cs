using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Bank
{
    private List<Account> _accounts = new List<Account>(); 
    private List<Transaction> _transactions = new List<Transaction>();
    
    public void AddAccount( Account account ) 
    {
        _accounts.Add(account);
    }
    public Account GetAccount( string name )
    {
        for( int i = 0 ; i < _accounts.Count; i++ )
        {
            if(name == _accounts[i].Name)
            {
                return _accounts[i];
            }
        }
        return null;
    }

    public void ExecuteTransaction( Transaction transaction )
    {
        _transactions.Add(transaction);
        transaction.Execute();
    }
    public void PrintTransactionHistory()
    {
        foreach ( Transaction transactionHistory in _transactions)
        {
            transactionHistory.Print();
        }
    }
}