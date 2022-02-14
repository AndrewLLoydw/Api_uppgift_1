namespace Api_uppgift_1.Models.Output
{
    public class CustomerOutput
    {
        public CustomerOutput()
        {

        }

        public CustomerOutput(int id, string firstName, string lastName, string email, CustomerAddressOutput customerAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CustomerAddress = customerAddress;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public CustomerAddressOutput CustomerAddress { get; set; }
    }
}
