using BankAccountProject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public class IHM
    {
        private Bank bank;

        public IHM()
        {
            bank = new Bank("Notre banque");
        }


        private void MainMenu()
        {
            Console.WriteLine("1 -- Liste des comptes ");
            Console.WriteLine("2 -- Créer un compte bancaire ");
            Console.WriteLine("3 -- Effectuer un dépôt ");
            Console.WriteLine("4 -- Effectuer un retrait ");
            Console.WriteLine("5 -- Afficher les opérations et solde ");
            Console.WriteLine("6 -- Calcule Interet ");

            Console.Write("\nVotre choix : ");
        }

        private void AccountMenu()
        {
            Console.WriteLine("1 -- Créer un compte courant ");
            Console.WriteLine("2 -- Créer un compte épargne ");
            Console.WriteLine("3 -- Créer un compte payant");
        }

        private void Next()
        {
            Console.WriteLine("Une touche pour continuer...");
            Console.ReadLine();
            Console.Clear();
        }

        public void Start()
        {
            string choice;
            do
            {
                MainMenu();
                choice = Console.ReadLine();
                Console.Clear();
                switch(choice)
                {
                    case "1":
                        ListAccountAction();
                        break;
                    case "2":
                        CreateAccountAction();
                        break;
                    case "3":
                        DepositAction();
                        break;
                    case "4":
                        WithDrawAction();
                        break;
                    case "5":
                        DisplayAccountAction();
                        break;
                    case "6":
                        InterestAction();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Erreur de menu");
                        break;
                }
                Next();
            } while (choice != "0");
        }

        private void ListAccountAction()
        {
            Console.WriteLine("---- Liste Comptes ----");

            //bank.Accounts.ForEach(c =>
            //{
            //    Console.WriteLine(c);
            //}) => version liste;

            new AccountDAO().FindAll().ForEach(c =>
            {
                c.Operations = new OperationDAO().FindAll(c.Id);
                Console.WriteLine(c);
            });
        }

        private void CreateAccountAction()
        {
            Console.WriteLine("Information client : ");
            Console.Write("Nom du client : ");
            string lastName = Console.ReadLine();
            Console.Write("Prénom du client : ");
            string firstName = Console.ReadLine();
            Console.Write("Téléphone du client : ");
            string phone = Console.ReadLine();
            Console.Write("Email du client : ");
            string email = Console.ReadLine();
            Customer customer = bank.CreateCustomer(firstName, lastName, phone, email);
            Console.Write("Un solde Initial ? ");
            decimal.TryParse(Console.ReadLine(), out decimal initialAmount);
            
            AccountMenu();
            
            string choice = Console.ReadLine();
            Account account = null;
            string message = "";
            switch(choice)
            {
                case "1":
                    account = bank.CreateSimpleAccount(customer, initialAmount);
                    message = "Compte courant";
                    break;
                case "2":
                    Console.Write("Taux d'interet : ");
                    decimal.TryParse(Console.ReadLine(), out decimal interest);
                    account = bank.CreateSavingAccount(customer, interest, initialAmount);
                    message = "Compte épargne";
                    break;
                case "3":
                    account = bank.CreatePaidAccount(customer, initialAmount);
                    message = "Compte payant";
                    break;
            }
            if(account != null)
            {
                Console.WriteLine($"Compte {message} crée avec Id {account.Id}");
                
            }
            else
            {
                Console.WriteLine("Erreur de création de compte ");
            }
        }

        private Account FindAccountAction()
        {
            Console.Write("Numéro de compte : ");
            int.TryParse(Console.ReadLine(), out int id);
            Account account = bank.FindAccount(id);
            if(account == null)
            {
                Console.WriteLine("Aucun compte avec cet id !!! ");
            }
            return account;
        }

        private void DepositAction()
        {
            Account account = FindAccountAction();
            if(account != null)
            {
                Console.Write("Montant dépôt : ");
                decimal.TryParse(Console.ReadLine(), out decimal amount);
                Operation operation = new Operation(amount);
                if (account.Deposit(operation) && new OperationDAO().Save(operation, account.Id) && new AccountDAO().Update(account))
                {
                    Console.WriteLine("Dépôt effectué !!! ");
                }
                else
                {
                    Console.WriteLine("Erreur dépôt ");
                }
            }
        }

        private void WithDrawAction()
        {
            Account account = FindAccountAction();
            if (account != null)
            {
                Console.Write("Montant retrait : ");
                decimal.TryParse(Console.ReadLine(), out decimal amount);
                Operation operation = new Operation(amount * -1);
                if (account.WithDraw(operation) && new OperationDAO().Save(operation, account.Id) && new AccountDAO().Update(account))
                {
                    Console.WriteLine("retrait effectué !!! ");
                }
                else
                {
                    Console.WriteLine("Erreur retrait ");
                }
            }
        }

        private void DisplayAccountAction()
        {
            Account account = FindAccountAction();
            if (account != null)
            {
                Console.WriteLine(account);
            }
        }

        private void InterestAction()
        {
            Account account = FindAccountAction();
            if (account != null && account is SavingAccount savingAccount)
            {
                if(savingAccount.MakeInterest())
                {
                    Console.WriteLine("Calcule Interet Ok !!! ");
                }
            }
        }

        
    }
}
