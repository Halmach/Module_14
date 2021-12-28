namespace Module_14
{
    internal class Contact
    {
        public Contact()
        {
        }

        public string Name { get; set; }
        public long Phone { get; set; }
    }

    internal class ContactExtended
    {
        public ContactExtended(string name, string lastName, long phoneNumber, string email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public string Name { get; }
        public string LastName { get; }
        public long PhoneNumber { get; }
        public string Email { get; }
    }

}