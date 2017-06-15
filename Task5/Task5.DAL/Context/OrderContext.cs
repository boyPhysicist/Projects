using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Entities;

namespace Task5.DAL.Context
{
    public class OrderContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        static OrderContext()
        {
            Database.SetInitializer<OrderContext>(new StoreDbInitializer());
        }

        public OrderContext(string connectionString)
            : base(connectionString)
        {
        }

    }

   
}
