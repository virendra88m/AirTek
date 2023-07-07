using AirTek.Models;
using Newtonsoft.Json;

namespace AirTek.Ops
{
    public class OrderOps
    {
        /// <summary>
        /// Load orders from orders.json in to Dictionary<string, Order>
        /// </summary>
        /// <returns> Dictionary<string, Order> </returns>
        public static Dictionary<string, Order> LoadOrders()
        {
            string json = File.ReadAllText("Data/orders.json");
            return JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
        }
    }
}