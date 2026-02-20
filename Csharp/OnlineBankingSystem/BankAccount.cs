using System;

public class BankAccount
{
    public string AccountNumber;
    public string AccountHolderName;

    private double balance;

    
    private string transaction1;
    private string transaction2;
    private string transaction3;

    private int year1;
    private int year2;
    private int year3;

    public BankAccount(string accNo, string name, double initialBalance)
    {
        AccountNumber = accNo;
        AccountHolderName = name;
        balance = initialBalance;

        transaction1 = "Account Created";
        year1 = 2026; 
    }

    public void Deposit(double amount)
    {
        balance += amount;
        SaveTransaction("Deposited: " + amount);
        Console.WriteLine("Deposit Successful");
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient Balance");
        }
        else
        {
            balance -= amount;
            SaveTransaction("Withdrawn: " + amount);
            Console.WriteLine("Withdrawal Successful");
        }
    }

    public void Transfer(BankAccount receiver, double amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient Balance");
        }
        else
        {
            balance -= amount;
            receiver.Deposit(amount);
            SaveTransaction("Transferred: " + amount);
            Console.WriteLine("Transfer Successful");
        }
    }

    private void SaveTransaction(string message)
    {
        
        transaction3 = transaction2;
        year3 = year2;

        transaction2 = transaction1;
        year2 = year1;

        transaction1 = message;
        year1 = 2026;   
    }

    public void ShowBalance()
    {
        Console.WriteLine("Current Balance: " + balance);
    }

    public void ShowTransactions()
    {
        Console.WriteLine("Transactions in last 1 year:");

        if (year1 >= 2025 && transaction1 != null)
            Console.WriteLine(transaction1);

        if (year2 >= 2025 && transaction2 != null)
            Console.WriteLine(transaction2);

        if (year3 >= 2025 && transaction3 != null)
            Console.WriteLine(transaction3);
    }

    public void CheckBookRequest()
    {
        Console.WriteLine("Check Book Allotted Successfully");
    }
}