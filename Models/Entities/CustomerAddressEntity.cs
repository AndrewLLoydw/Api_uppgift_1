using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_uppgift_1.Models.Entities
{
    public class CustomerAddressEntity
    {
        public CustomerAddressEntity(string streetName, int postalCode, string city, string country)
        {
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string StreetName { get; set; }

        [Required]
        [Column(TypeName = "char(5)")]
        public int PostalCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Updated { get; set; }

        public virtual ICollection<CustomerEntity> Customers { get; set; }
    }
}
