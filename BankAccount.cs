using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This file will contain the definition of a bank account. Object Oriented programming organizes code by creating types in the form of classes. These classes contain the code that represents a specific entity. The BankAccount class represents a bank account. The code implements specific operations through methods and properties. In this tutorial, the bank account supports this behavior:
//It has a 10-digit number that uniquely identifies the bank account.
//It has a string that stores the name or names of the owners.
//The balance can be retrieved.
//It accepts deposits.
//It accepts withdrawals.
//The initial balance must be positive.
//Withdrawals cannot result in a negative balance.

//There are 7 MEMBERS of the BankAccount class where the first 5 are PROPERTIES and the last 3 are METHODS.

namespace classes
{
    public class BankAccount
    {
        //Here are the 5 PROPERTIES of the BankAccount class:
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; }
        public decimal Balance 
        {
            get
            {
                decimal balance = 0;
                foreach (Transaction transaction in allTransactions)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }
        private List<Transaction> allTransactions = new List<Transaction>();

        //Here's our constructor:
        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        //Here are the 3 METHODS of the BankAccount class:
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
            }
            Transaction deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive.");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal.");
            }
            Transaction withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        //The throw statement throws an exception > Execution of the current block ends and the control transfers to the first matching catch block found in the call stack (refer to Program.cs).

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            decimal balance = 0;
            report.AppendLine("Here's your account history:");
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (Transaction transaction in allTransactions)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Notes}");
            }

            return report.ToString();
        }
    }
}
