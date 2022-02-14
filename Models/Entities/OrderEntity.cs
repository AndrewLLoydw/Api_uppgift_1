using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_uppgift_1.Models.Entities
{
    public enum Statuses
    {
        Created,
        Sent,
        Delivered
    }

    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Updated { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public List<ProductEntity> Products { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public CustomerEntity Customer { get; set; }
        public ProductEntity Product { get; set; }
    }
}
