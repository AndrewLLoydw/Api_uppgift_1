namespace Api_uppgift_1.Models.Update
{
    public class ProductUpdateModel
    {
        public ProductUpdateModel(string productName, string productDescription, decimal productPrice)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
        }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
