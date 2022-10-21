using BankAccountProject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public class Bank
    {
        private string _name;
        private List<Account> accounts;
        private CustomerDAO customerDAO;
        private AccountDAO accountDAO;
        public Bank(string name)
        {
            _name = name;
            accounts = new List<Account>();
        }

        public List<Account> Accounts { get => accounts; }

        public Customer CreateCustomer(string firstName, string lastName, string Phone, string email)
        {
            Customer customer = new Customer(firstName, lastName, Phone, email);
            customerDAO = new CustomerDAO();
            if (customerDAO.Save(customer))
            {
                return customer;
            }
            else
            { 
                return null;
            }
        }

        public Account CreateSimpleAccount(Customer customer, decimal initialAmount = 0)
        {
            SimpleAccount account = new SimpleAccount(customer, initialAmount);
            account.NegatifAmount += Notification.NotificationNegatifAmount;
            //accounts.Add(account); => uniquement dans la version avec les liste
            accountDAO = new AccountDAO();
            if(accountDAO.Save(account))
            {
                return account;
            }
            else
            {
                return null;
            }
        }

        public Account CreatePaidAccount(Customer customer, decimal initialAmount = 0)
        {
            PaidAccount account = new PaidAccount(customer, initialAmount);
            accounts.Add(account);
            return account;
        }

        public Account CreateSavingAccount(Customer customer, decimal interest, decimal initialAmount = 0)
        {
            SavingAccount account = new SavingAccount(customer, interest, initialAmount);
            accounts.Add(account);
            return account;
        }

        public Account FindAccount(int id)
        {
            
            //return Accounts.FirstOrDefault(c => c.Id == id); => on recherche dans la liste
            Account account = new AccountDAO().FindById(id);
            account.Operations = new OperationDAO().FindAll(id);
            return account;
        }
        
    }
}
