using BankAccountProject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public abstract class Account
    {
        private static int count = 0;
        private int id;
        protected decimal totalAmount;
        private Customer _customer;
        protected List<Operation> operations;

        //Constructeur par défaut, il sera utiliser dans la couche DAO
        public Account()
        {

        }

        public Account(Customer customer, decimal initialAmount = 0)
        {
            _customer = customer;
            id = ++count;
            operations = new List<Operation>();
            if (initialAmount > 0)
            {
                Deposit(new Operation(initialAmount));
            }
            else
            {
                totalAmount = 0;
            }
        }

        public int Id { get => id; set => id = value; }
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        public Customer Customer { get => _customer; set => _customer = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }

        public virtual bool Deposit(Operation operation)
        {
            if(operation.Amount > 0)
            {
                //operations.Add(operation); => pour la version avec liste uniquement
                totalAmount += operation.Amount;
                return true;
            }
            return false;
        }

        public virtual bool WithDraw(Operation operation)
        {
            if(operation.Amount < 0 && Math.Abs(operation.Amount) <= totalAmount)
            {
                operations.Add(operation);
                totalAmount += operation.Amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string result = Customer.ToString() + "\n";
            result += $"Solde : {TotalAmount}\n";
            result += "Liste Opérations : \n";
            Operations.ForEach(o =>
            {
                result += o.ToString() + "\n";
            });
            return result;
        }
    }
}
