using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.DAO
{
    public abstract class BaseDAO<T>
    {
        protected static string request;
        protected static SqlConnection connection;
        protected static SqlCommand command;
        protected static SqlDataReader reader;

        public abstract bool Save(T element);
        public abstract T FindById(int id);

        public abstract List<T> FindAll();
    }
}
