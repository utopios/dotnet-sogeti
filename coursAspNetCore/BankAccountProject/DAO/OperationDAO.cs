using BankAccountProject.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.DAO
{
    public class OperationDAO : BaseDAO<Operation>
    {
        public override List<Operation> FindAll()
        {
            throw new NotImplementedException();
        }

        public override Operation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Operation element)
        {
            throw new NotImplementedException();
        }

        public  bool Save(Operation element, int accountId)
        {
            connection = DataBase.Connection;
            request = "INSERT INTO operation (amount, account_id, date_operation) OUTPUT INSERTED.ID " +
                "values (@amount, @account_id, @date_operation)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@amount", element.Amount));
            command.Parameters.Add(new SqlParameter("@account_id", accountId));
            command.Parameters.Add(new SqlParameter("@date_operation", element.OperationDateTime));

            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public List<Operation> FindAll(int accountId)
        {
            List<Operation> operations = new();
            connection = DataBase.Connection;
            request = "SELECT id, amount, date_operation from operation where account_id=@account_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@account_id", accountId));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Operation operation = new Operation()
                {
                    Amount = reader.GetDecimal(1),
                    Id = reader.GetInt32(0),
                    OperationDateTime = reader.GetDateTime(2)
                };
                operations.Add(operation);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return operations;
        }
    }
}
