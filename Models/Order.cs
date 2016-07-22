using System.Collections.Generic;

namespace AspNetCoreDocker.Models
{
    public class Order
    {
        public int Number { get; set; }
        public List<OrderItem> Items { get; set; }

        public Order()
        {
            this.Items = new List<OrderItem>();
        }
    }
}