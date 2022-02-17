namespace Api_uppgift_1.Models
{
    public class CustomerAddressModel
    {
        public CustomerAddressModel(string streetName, int postalCode, string city, string country)
        {
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
