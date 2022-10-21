using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public class PaidAccount : Account
    {
        private static decimal OPERATION_COST = 1;
        public PaidAccount(Customer customer, decimal initialAmount = 0) : base(customer, initialAmount)
        {
        }

        public override bool Deposit(Operation operation)
        {
            if(operation.Amount > OPERATION_COST )
            {
                return base.WithDraw(new Operation(OPERATION_COST * -1));
            }
            return false;
        }

        public override bool WithDraw(Operation operation)
        {
            if(TotalAmount > OPERATION_COST + Math.Abs(operation.Amount))
            {
                return base.WithDraw(new Operation(OPERATION_COST * -1)) && base.WithDraw(operation);
            }
            return false;
        }
    }
}
