using System;

namespace AspNetCoreDocker.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; } 

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}