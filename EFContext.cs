using Microsoft.EntityFrameworkCore;
using AspNetCoreDocker.Models;

namespace AspNetCoreDocker
{
    public class EFContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set; }        

        public EFContext(DbContextOptions<EFContext> options): base(options)
        {

        }
    }
}