namespace Api_uppgift_1.Models.Create
{
    public class CreateOrder
    {
        public CreateOrder()
        {

        }

        public int customerId;
        public List<CreateProductList> products;

        public int CustomerId
        {
            get { return customerId; } set { customerId = value; }
        }
        public List<CreateProductList> product
        {
            get {return product;}
            set
            {
                var orderProducts = new List<CreateProductList>();
                foreach (var item in value)
                {
                    orderProducts.Add(new CreateProductList() { ProductNumber = item.ProductNumber, ProductPrice = item.ProductPrice });
                };

                products = orderProducts;
            }
        }
        public string Status { get; set; }

        public DateTime OrderCreated { get; set; } = DateTime.Now;
    }
}
