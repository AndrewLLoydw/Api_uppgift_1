using System.ComponentModel.DataAnnotations;

namespace Api_uppgift_1.Models.Entities
{
    public class OrderHandlerEntity
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int HandlerId { get; set; }

        public OrderEntity Order { get; set; }

        public HandlerEntity Handler { get; set; }
    }
}
