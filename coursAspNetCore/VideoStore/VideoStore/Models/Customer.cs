using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Models
{
    [Table("videostore_customer")]
    public class Customer
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("first_name")]
        public string FirstName { get; set; }


        [Column("last_name")]
        public string LastName { get; set; }


        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        public List<Loan> Loans { get; set; }

        public Customer()
        {
            Loans = new List<Loan>();
        }
    }
}
