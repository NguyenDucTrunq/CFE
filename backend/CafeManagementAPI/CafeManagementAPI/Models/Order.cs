namespace CafeManagementAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
