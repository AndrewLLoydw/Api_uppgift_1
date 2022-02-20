namespace Api_uppgift_1.Models
{
    public class OrderModel
    {
        public OrderModel()
        {

        }

        public OrderModel(int id, DateTime orderCreated, string status, CustomerModel customer, ICollection<ProductModel> products, decimal orderPrice)
        {
            Id = id;
            OrderCreated = orderCreated;
            Status = status;
            Customer = customer;
            Products = products;
            OrderPrice = orderPrice;
        }

        public int Id { get; set; }
        public DateTime OrderCreated { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public CustomerModel Customer { get; set; }


        public ICollection<ProductModel> Products { get; set; }
        public decimal OrderPrice { get; set; }

    }
}
