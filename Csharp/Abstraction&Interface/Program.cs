using System;
using System.Collections.Specialized;

interface Account
{
    void deposit(double amount); 
    void withdraw(double amount);
    double getbalance();
}

abstract class Accountbase
{
    protected double balance;
    public void showbalance()
    {
        Console.WriteLine($"Current Balance:{balance}");
    }

public abstract void withdraw( double amount );
}

class SavingsAccount : Accountbase, Account
{
    public void deposit(double amount) { 
    balance += amount;
    }

    public  override void withdraw(double amount)
    {
        if(balance>=amount)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }
    public double getbalance() { return balance; }  
}
class Program
{
    static void Main(String[] args)
    {
        Account account = new SavingsAccount();
        account.deposit(5000);
        account.withdraw(1200);

        Console.WriteLine($"The balance is : {account.getbalance()}");
    }
}