using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test BankAccount ===========================================================
            var account = new BankAccount("Hermione Granger", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with initial balance of {account.Balance}");
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            // Test that initial balances must be positive.
            try
            {
                BankAccount invalidAccount = new BankAccount("Ronald Weasley", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance.");
                Console.WriteLine(e.ToString());
            }

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(account.GetAccountHistory());

            //Test GiftCardAccount ===========================================================
            GiftCardAccount giftCard = new GiftCardAccount("Gift Card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "Get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "Buy groceries");
            giftCard.PerformMonthEndTransactions();
            giftCard.MakeDeposit(27.50M, DateTime.Now, "Add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            //Test InterestEarningAccount ====================================================
            InterestEarningAccount savings = new InterestEarningAccount("Savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "Save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.Write(savings.GetAccountHistory());

            //Test LineOfCreditAccount =======================================================
            LineOfCreditAccount lineOfCredit = new LineOfCreditAccount("Line of Credit", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            //lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs"); //Throws an error - too much to borrow!
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }
    }
}
