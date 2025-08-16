using System;

class Program
{
    static void Main()
    {
        decimal balance = 1000m;
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nWelcome to the ATM!\n");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");

            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine($"\nYour balance is: {balance} EGP");
                    break;

                case "2":
                    Console.Write("Enter amount to deposit: ");
                    decimal deposit = decimal.Parse(Console.ReadLine());
                    if (deposit > 0)
                    {
                        balance += deposit;
                        Console.WriteLine($"Balance is now: {balance} EGP");
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    break;

                case "3":
                    Console.Write("Enter amount to withdraw: ");
                    decimal withdraw = decimal.Parse(Console.ReadLine());
                    if (withdraw > 0 && withdraw <= balance)
                    {
                        balance -= withdraw;
                        Console.WriteLine($"Balance is now: {balance} EGP");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance or invalid amount.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the ATM!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
