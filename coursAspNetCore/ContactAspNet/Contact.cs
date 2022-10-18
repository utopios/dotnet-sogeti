namespace ContactAspNet
{
    public class Contact
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Nom {LastName}, Prénom {FirstName}, téléphone {PhoneNumber}, Email {Email}";
        }
    }
}
