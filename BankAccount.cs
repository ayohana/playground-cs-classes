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

//There are 5 MEMBERS of the BankAccount class where the first 3 are PROPERTIES and the last 2 are METHODS.

namespace classes
{
    public class BankAccount
    {

        //Here are the three PROPERTIES of the BankAccount class:
        public string Number { get; }
        public string Owner { get; }
        public decimal Balance { get; }
        

        //Here's our constructor:
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
        }

        //Here are the two METHODS of the BankAccount class:
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {

        }
    }
}
