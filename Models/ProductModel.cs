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

        public ProductModel(int productNumber, string productName, string productDescription, decimal productPrice)
        {
            ProductNumber = productNumber;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
        }

        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
