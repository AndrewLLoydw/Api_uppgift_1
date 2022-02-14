using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_uppgift_1.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "char(50)")]
        public int ProductNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductDescription { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public decimal ProductPrice { get; set; }

        public int SubCategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
