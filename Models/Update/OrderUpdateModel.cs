namespace Api_uppgift_1.Models.Update
{
    public class OrderUpdateModel
    {
        public OrderUpdateModel( string status)
        {
            Status = status;
        }

        public int Id { get; set; }
        public string Status { get; set; }
    }
}

