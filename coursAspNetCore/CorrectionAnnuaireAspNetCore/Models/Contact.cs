using System.ComponentModel.DataAnnotations.Schema;

namespace CorrectionAnnuaireAspNetCore.Models
{

    [Table("contact")]
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }
    }
}
