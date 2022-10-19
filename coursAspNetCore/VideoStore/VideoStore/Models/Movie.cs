using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Models
{
    [Table("videostore_movie")]
    public class Movie
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("director")]
        public string Director { get; set; }

        [Column("description", TypeName ="text")]
        public string Description { get; set; }

        [Column("score")]
        public int Score { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("loan_id")]
        public int? LoanId { get; set; }

        public Loan Loan { get; set; }
    }
}
