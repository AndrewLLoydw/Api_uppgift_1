namespace Api_uppgift_1.Models.Update
{
    public class OrderUpdateModel
    {
        public OrderUpdateModel(decimal orderPrice, string status)
        {
            OrderPrice = orderPrice;
            Status = status;
        }

        public decimal OrderPrice { get; set; }
        public string Status { get; set; }
    }
}
}
