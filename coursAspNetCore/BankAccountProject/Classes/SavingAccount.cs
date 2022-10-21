using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public class SavingAccount : Account
    {
        private decimal _interset;
        public SavingAccount(Customer customer, decimal interest, decimal initialAmount = 0) : base(customer, initialAmount)
        {
            _interset = interest;
        }

        //public override bool Deposit(Operation operation)
        //{
        //    return base.Deposit(operation);
        //}

        //public override bool WithDraw(Operation operation)
        //{
        //    return base.WithDraw(operation);
        //}
        public bool MakeInterest()
        {
            return base.Deposit(new Operation(TotalAmount * _interset / 100));
        }
    }
}
