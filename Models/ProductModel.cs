namespace Api_uppgift_1.Models
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(decimal productPrice)
        {
            ProductPrice = productPrice;
        }

        public ProductModel(string productNumber, string productName, string productDescription, decimal productPrice, string categoryName)
        {
            ProductNumber = productNumber;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            CategoryName = categoryName;
        }

        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
