using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Models
{
    [Table("videostore_loan")]
    public class Loan
    {
        public int Id { get; set; }

        public DateTime BorrowDateTime { get; set; }

        public List<Movie> Movies { get; set; }

        public Loan()
        {
            Movies = new List<Movie>();
        }

        [Column("customer_id")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer {get;set;}
    }
}
