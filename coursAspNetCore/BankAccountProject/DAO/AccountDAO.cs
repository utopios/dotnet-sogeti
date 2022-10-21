using BankAccountProject.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.DAO
{
    public class AccountDAO : BaseDAO<Account>
    {
        public override List<Account> FindAll()
        {
            List<Account> accounts = new List<Account>();   
            connection = DataBase.Connection;
            request = "SELECT ac.amount, c.id, c.first_name, c.last_name, c.phone, c.email, ac.id from account as ac inner join customer as c on c.id = ac.customer_id ";
            command = new SqlCommand(request, connection);
         
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Customer customer = new Customer(reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5))
                {
                    Id = reader.GetInt32(1)
                };
                Account account = new SimpleAccount()
                {
                    Id = reader.GetInt32(6),
                    Customer = customer,
                    TotalAmount = reader.GetDecimal(0)
                };
                accounts.Add(account);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return accounts;
        }

        public override Account FindById(int id)
        {
            Account account = null;
            connection = DataBase.Connection;
            request = "SELECT ac.amount, c.id, c.first_name, c.last_name, c.phone, c.email from account as ac inner join customer as c on c.id = ac.customer_id where ac.id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                Customer customer = new Customer(reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5))
                {
                    Id = reader.GetInt32(1)
                };
                account = new SimpleAccount()
                {
                    Id = id,
                    Customer = customer,
                    TotalAmount= reader.GetDecimal(0)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return account;
        }

        public override bool Save(Account element)
        {
            connection = DataBase.Connection;
            request = "INSERT INTO account (amount, customer_id) OUTPUT INSERTED.ID " +
                "values (@amount, @customer_id)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@amount", element.TotalAmount));
            command.Parameters.Add(new SqlParameter("@customer_id", element.Customer.Id));

            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public bool Update(Account element)
        {
            connection = DataBase.Connection;
            request = "UPDATE account set amount=@amount where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@amount", element.TotalAmount));
            command.Parameters.Add(new SqlParameter("@id", element.Id));

            connection.Open();
            int nbLine = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbLine == 1;
        }
    }
}
