using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_uppgift_1.Models.Entities
{
    public class HandlerEntity
    {

        public HandlerEntity(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
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

        public virtual ICollection<OrderHandlerEntity> Orders { get; set; }
    }
}
