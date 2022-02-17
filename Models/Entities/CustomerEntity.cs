using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_uppgift_1.Models.Entities
{

    [Index(nameof(Email), IsUnique = true)]

    public class CustomerEntity
    {
        public CustomerEntity()
        {

        }

        public CustomerEntity(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public CustomerEntity(string firstName, string lastName, string email, string password, CustomerAddressModel address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Address = address;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Updated { get; set; }

        public int AddressId { get; set; }

        public CustomerAddressModel Address { get; set; }

        public CustomerAddressEntity AddressEntity { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
