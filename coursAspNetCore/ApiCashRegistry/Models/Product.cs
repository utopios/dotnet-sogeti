using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCashRegistry.Models
{

    [Table("product")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
        
        [Column("stock")]
        public int Stock { get; set; }

        public List<OrderProduct> Orders { get; set; }

        public Product()
        {
            Orders = new List<OrderProduct>();
        }
    }

}
