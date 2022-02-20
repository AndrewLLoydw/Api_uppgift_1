namespace Api_uppgift_1.Models
{
    public class ProductListModel
    {
        public ProductListModel()
        {

        }
        public ProductListModel(string productNumber, string productName, decimal productPrice)
        {
            ProductNumber = productNumber;
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public ProductListModel(int id, string productNumber, string productName, decimal productPrice)
        {
            Id = id;
            ProductNumber = productNumber;
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public int Id { get; set; }

        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
