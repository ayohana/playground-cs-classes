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

//There are 10 MEMBERS of the BankAccount class where the first 6 are PROPERTIES and the last 4 are METHODS.

//After building this program, you get requests to add features to it. It works great in the situation where there is only one bank account type. Over time, needs change, and related account types are requested:
//An interest earning account that accrues interest at the end of each month.
//A line of credit that can have a negative balance, but when there's a balance, there's an interest charge each month.
//A pre-paid gift card account that starts with a single deposit, and only can be paid off. It can be refilled once at the start of each month.

//3 new classes created: InterestEarningAccount, LineOfCreditAccount, GiftCardAccount.
//Each of these classes inherits the shared behavior from their shared base class, the BankAccount class. Write the implementations for new and different functionality in each of the derived classes. These derived classes already have all the behavior defined in the BankAccount class.

namespace classes
{
    public class BankAccount
    {
        //Here are the 6 PROPERTIES of the BankAccount class:
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
        private readonly decimal minimumBalance;

        //Let's use constructor chaining to have one constructor call another. Here are our two constructors:
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
        {
        }
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            this.Owner = name;
            this.minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }


        //Here are the 4 METHODS of the BankAccount class:
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
            if (Balance - amount < minimumBalance)
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

        public virtual void PerformMonthEndTransactions()
        {

        }
        //The preceding code shows how you use the virtual keyword to declare a method in the base class that a derived class may provide a different implementation for.
        //A virtual method is a method where any derived class may choose to reimplement.
        //The derived classes use the override keyword to define the new implementation. 
        //Typically you refer to this as "overriding the base class implementation".
        //The virtual keyword specifies that derived classes may override the behavior.
    }
}
