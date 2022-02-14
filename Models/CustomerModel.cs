using Api_uppgift_1.Models.Entities;

namespace Api_uppgift_1.Models
{
    public class CustomerModel
    {

        public CustomerModel()
        {

        }

        public CustomerModel(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public CustomerModel(string firstName, string lastName, string email, CustomerAddressEntity address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public CustomerModel(int id, string firstName, string lastName, string email, CustomerAddressEntity address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";

        public CustomerAddressEntity Address { get; set; }


        public string GetDisplayName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
