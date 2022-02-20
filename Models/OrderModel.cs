namespace Api_uppgift_1.Models
{
    public class OrderModel
    {
        private object id;
        private object createdDate;
        private CustomerModel customerModel;
        private List<ProductListModel> line;
        private object órderPrice;

        public OrderModel()
        {

        }

        public OrderModel(int id, DateTime created, string status, CustomerModel customer, ICollection<ProductModel> products, decimal orderPrice)
        {
            Id = id;
            Created = created;
            Status = status;
            Customer = customer;
            Products = products;
            OrderPrice = orderPrice;
        }

        public OrderModel(int id, DateTime created, string status, CustomerModel customerModel, List<ProductListModel> productListModels, decimal orderPrice)
        {
            this.id = id;
            Created = created;
            Status = status;
            this.customerModel = customerModel;
            OrderPrice = orderPrice;
        }

        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public CustomerModel Customer { get; set; }
        public ICollection<ProductModel> Products { get; set; }
        public decimal OrderPrice { get; set; }

    }
}
