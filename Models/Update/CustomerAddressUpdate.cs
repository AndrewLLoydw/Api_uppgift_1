namespace Api_uppgift_1.Models.Update
{
    public class CustomerAddressUpdate
    {
        public CustomerAddressUpdate(string streetName, int postalCode, string city, string country)
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
