namespace Api_uppgift_1.Models.Create
{
    public class CreateProductModel
    {
        public CreateProductModel()
        {

        }

        public CreateProductModel(string productName, string productDescription, decimal productPrice, string categoryName, DateTime productCreated)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            CategoryName = categoryName;
            ProductCreated = productCreated;
        }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public DateTime ProductCreated { get; set; } = DateTime.Now;
    }
}
