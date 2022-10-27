namespace CorrectionAnnuaireBlazor.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Phone { get; set; } 

        public List<Email> Emails { get; set; }

        public Contact()
        {
            Emails = new List<Email>();
        }
    }
}
