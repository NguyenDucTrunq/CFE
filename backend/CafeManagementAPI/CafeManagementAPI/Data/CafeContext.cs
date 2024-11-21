using Microsoft.EntityFrameworkCore;
using CafeManagementAPI.Models;

namespace CafeManagementAPI.Data
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; } // Pluralized table name
        public DbSet<Product> Products { get; set; } // Pluralized table name
        public DbSet<Order> Orders { get; set; } // Pluralized table name
        public DbSet<OrderDetail> OrderDetails { get; set; } // Pluralized table name

    }
}
