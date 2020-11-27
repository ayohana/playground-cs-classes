using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Hermione Granger", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with initial balance of {account.Balance}");
        }
    }
}
