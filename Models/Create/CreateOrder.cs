namespace Api_uppgift_1.Models.Create
{
    public class CreateOrder
    {
        public CreateOrder()
        {

        }

        public CreateOrder(int customerId, List<CreateProductList> products, string status, decimal orderPrice)
        {
            CustomerId = customerId;
            Product = products;
            Status = status;
            OrderPrice = orderPrice;

        }

        public List<CreateProductList> Product;

        public int CustomerId { get; set; }
        public List<CreateProductList> product
        {
            get {return Product;}
            set
            {
                var orderProducts = new List<CreateProductList>();
                foreach (var item in value)
                {
                    orderProducts.Add(new CreateProductList() { ProductNumber = item.ProductNumber, ProductPrice = item.ProductPrice });
                };

                Product = orderProducts;
            }
        }
        public string Status { get; set; }

        public decimal OrderPrice { get; set; }

        public DateTime OrderCreated { get; set; } = DateTime.Now;
    }
}
