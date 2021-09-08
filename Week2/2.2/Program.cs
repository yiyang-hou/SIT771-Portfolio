using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Account account = new Account("Jake's Account", 200000);

        account.Print();
        account.Deposit(100);
        account.Print();    
        account.Wiithdraw(50);    
        account.Print();  

        Account account1 = new Account("Yiyang's Account", 1000000);

        account1.Print();
        account1.Deposit(1000);
        account1.Print();
        account1.Deposit(5000);
        account1.Print();
        account1.Wiithdraw(500);
        account1.Print();
        account1.Wiithdraw(250);
        account1.Print();
    }
}
