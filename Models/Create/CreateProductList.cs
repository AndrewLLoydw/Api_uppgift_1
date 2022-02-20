namespace Api_uppgift_1.Models.Create
{
    public class CreateProductList
    {
        public CreateProductList()
        {

        }

        public CreateProductList(string productNumber, int productPrice)
        {
            ProductNumber = productNumber;
            ProductPrice = productPrice;
        }

        public string ProductNumber { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
