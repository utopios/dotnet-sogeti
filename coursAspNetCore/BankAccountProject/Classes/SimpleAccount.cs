using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public class SimpleAccount : Account
    {
        
        public event Action<SimpleAccount> NegatifAmount;
        
        public SimpleAccount() : base()
        {

        }
        
        public SimpleAccount(Customer customer, decimal initialAmount = 0) : base(customer, initialAmount)
        {

        }

        public override bool Deposit(Operation operation)
        {
            return base.Deposit(operation);
        }

        public override bool WithDraw(Operation operation)
        {
            if(operation.Amount < 0)
            {
                operations.Add(operation);
                totalAmount += operation.Amount;
                if(TotalAmount < 0 && NegatifAmount != null)
                {
                    NegatifAmount(this);
                }
                return true;
            }
            return false;
        }

    }
}
