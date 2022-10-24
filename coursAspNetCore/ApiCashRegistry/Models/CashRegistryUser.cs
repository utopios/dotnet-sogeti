using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCashRegistry.Models
{
    [Table("cashregistry_user")]
    public class CashRegistryUser
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }    

        public List<Order> Orders { get; set; }

        public CashRegistryUser()
        {
            Orders = new List<Order>();
        }
    }
}
