using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public class Operation
    {
        private int id;
        private decimal _amount;
        private DateTime operationDateTime;
        private static int count = 0;
        public int Id { get => id; set => id = value; }
        public decimal Amount { get => _amount; set => _amount = value; }
        public DateTime OperationDateTime { get => operationDateTime; set => operationDateTime = value; }

        public Operation()
        {

        }

        public Operation(decimal amount)
        {
            _amount = amount;
            id = ++count;
            operationDateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"date opération : {OperationDateTime}, Montant : {Amount} €";
        }

    }
}
