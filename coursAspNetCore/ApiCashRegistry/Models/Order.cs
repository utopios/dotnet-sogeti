using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCashRegistry.Models
{

    [Table("order")]
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("date_time")]
        public DateTime OrderDate { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public List<OrderProduct> Products { get; set; }

        [ForeignKey("UserId")]
        public CashRegistryUser User { get; set; }

        public Order()
        {
            Products = new List<OrderProduct>();
        }

        public void UpdateAmount()
        {
            decimal total = 0;
            Products.ForEach(p =>
            {
                total += p.Qty * p.Product.Price;
            });
            Amount = total;
        }
    }
}
