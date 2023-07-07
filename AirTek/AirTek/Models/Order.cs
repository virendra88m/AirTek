namespace AirTek.Models
{
    public class Order
    {
        public string Destination { get; set; }
    }

    public class OrdersData
    {
        public Dictionary<string, Order> Orders { get; set; }
    }
}