using System;

class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount("101", "Sneh", 5000);
        BankAccount acc2 = new BankAccount("102", "Rahul", 3000);

        while (true)
        {
            Console.WriteLine("\n1. Balance Check");
            Console.WriteLine("2. View Transactions (1 Year)");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Transfer");
            Console.WriteLine("6. Staff Data Entry");
            Console.WriteLine("7. Search Account");
            Console.WriteLine("8. Check Book");
            Console.WriteLine("9. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 9)
                break;

            Console.Write("Select Account (1 or 2): ");
            int accChoice = Convert.ToInt32(Console.ReadLine());

            BankAccount selected = (accChoice == 1) ? acc1 : acc2;

            switch (choice)
            {
                case 1:
                    selected.ShowBalance();
                    break;

                case 2:
                    selected.ShowTransactions();
                    break;

                case 3:
                    Console.Write("Enter Amount: ");
                    double depositAmt = Convert.ToDouble(Console.ReadLine());
                    selected.Deposit(depositAmt);
                    break;

                case 4:
                    Console.Write("Enter Amount: ");
                    double withdrawAmt = Convert.ToDouble(Console.ReadLine());
                    selected.Withdraw(withdrawAmt);
                    break;

                case 5:
                    Console.Write("Enter Amount: ");
                    double transferAmt = Convert.ToDouble(Console.ReadLine());

                    if (selected == acc1)
                        acc1.Transfer(acc2, transferAmt);
                    else
                        acc2.Transfer(acc1, transferAmt);
                    break;

                case 6:
                    Console.Write("Enter Deposit Amount by Staff: ");
                    double staffAmt = Convert.ToDouble(Console.ReadLine());
                    selected.Deposit(staffAmt);
                    Console.WriteLine("Record Entered by Staff");
                    break;

                case 7:
                    Console.Write("Enter Account Number: ");
                    string search = Console.ReadLine();

                    if (acc1.AccountNumber == search)
                        Console.WriteLine("Account Found: " + acc1.AccountHolderName);
                    else if (acc2.AccountNumber == search)
                        Console.WriteLine("Account Found: " + acc2.AccountHolderName);
                    else
                        Console.WriteLine("Account Not Found");
                    break;

                case 8:
                    selected.CheckBookRequest();
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}