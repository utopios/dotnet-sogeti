using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private string phone;
        private string email;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set 
            {
                if (value.Length == 10)
                    phone = value;
                else
                    throw new Exception("Phone error");
            } 
        }
        public string Email { get => email; set => email = value; }
        public int Id { get; set; }
        public Customer(string firstName, string lastName, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

        public override string? ToString()
        {
            return $"Nom {LastName}, Prénom : {FirstName}, Tél: {Phone}, Email: {Email}";
        }
    }
}
