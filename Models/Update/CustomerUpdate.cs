namespace Api_uppgift_1.Models.Update
{
    public class CustomerUpdate
    {
        public CustomerUpdate(string firstName, string lastName, string email, string password, string streetName, int postalCode, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
