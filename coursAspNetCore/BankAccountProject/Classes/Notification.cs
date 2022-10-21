using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Classes
{
    public class Notification
    {
        public static void NotificationNegatifAmount(SimpleAccount account)
        {
            Console.WriteLine($"Compte : \n {account} \n est à decouvert");
        }
    }
}
