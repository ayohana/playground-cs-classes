using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Requirements for new class - A line of credit:
//Can have a negative balance, but not be greater in absolute value than the credit limit.
//Will incur an interest charge each month where the end of month balance isn't 0.
//Will incur a fee on each withdrawal that goes over the credit limit.

namespace classes
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                //Negate the balance to get a positive interest charge:
                decimal interest = -Balance * 0.07M;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }
    }
}
