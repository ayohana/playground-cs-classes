using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//The parameters to this new constructor match the parameter type and names of the base class constructor. You use the : base() syntax to indicate a call to a base class constructor. Some classes define multiple constructors, and this syntax enables you to pick which base class constructor you call. Once you've updated the constructors, you can develop the code for each of the derived classes.
//The requirements for the new InterestEarningAccount class can be stated as follows:
//An interest earning account will get a credit of 2% of the month-ending-balance.

namespace classes
{
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02M;
                MakeDeposit(interest, DateTime.Now, "Apply 2% monthly interest");
            }
        }
    }
}
