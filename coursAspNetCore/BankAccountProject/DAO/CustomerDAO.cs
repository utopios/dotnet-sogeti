using BankAccountProject.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.DAO
{
    public class CustomerDAO : BaseDAO<Customer>
    {
        public override List<Customer> FindAll()
        {
            throw new NotImplementedException();
        }

        public override Customer FindById(int id)
        {
            Customer customer = null;
            connection = DataBase.Connection;
            request = "SELECT first_name, last_name, phone, email from customer where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                customer = new Customer(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3))
                {
                    Id = id
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return customer;
        }

        public override bool Save(Customer element)
        {
            connection = DataBase.Connection;
            request = "INSERT INTO customer (first_name, last_name, phone, email) OUTPUT INSERTED.ID " +
                "values (@first_name, @last_name, @phone, @email)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@first_name", element.FirstName));
            command.Parameters.Add(new SqlParameter("@last_name", element.LastName));
            command.Parameters.Add(new SqlParameter("@phone", element.Phone));
            command.Parameters.Add(new SqlParameter("@email", element.Email));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }
    }
}
