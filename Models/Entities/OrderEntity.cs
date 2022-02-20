using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_uppgift_1.Models.Entities
{

    public class OrderEntity
    { 

        public OrderEntity()
        {

        }

        public OrderEntity(CustomerEntity customer, ICollection<ProductEntity> products, decimal orderPrice, string orderStatus)
        {
            Customer = customer;
            Products = products;
            OrderPrice = orderPrice;
            Status = orderStatus;
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Updated { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public ICollection<ProductEntity> Products { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public decimal OrderPrice { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public CustomerEntity Customer { get; set; }
        public ProductEntity Product { get; set; }
    }
}
