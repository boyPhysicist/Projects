using System.Collections.Specialized;
using System.Data.Entity;
using Task5.DAL.Entities;

namespace Task5.DAL.Context
{
    internal class StoreDbInitializer : DropCreateDatabaseIfModelChanges<OrderContext>
    {
        protected override void Seed(OrderContext db)
        {
            db.Products.Add(new Product { Name = "Product1", Price = 1 });
            db.Products.Add(new Product { Name = "Product2", Price = 2 });
            db.Products.Add(new Product { Name = "Product3", Price = 3 });
            db.Products.Add(new Product { Name = "Product4", Price = 4 });

            db.Managers.Add(new Manager {Name = "Manager1", Email = "email1@email.com"});
            db.Managers.Add(new Manager { Name = "Manager2", Email = "email2@email.com" });
            
            db.Clients.Add(new Client { Name = "Client1", Email = "clientEmail1@email.com" });
            db.Clients.Add(new Client { Name = "Client2", Email = "clientEmail2@email.com" });
            db.Clients.Add(new Client { Name = "Client3", Email = "clientEmail2@email.com" });
            db.Clients.Add(new Client { Name = "Client2", Email = "clientEmail2@email.com" });
            db.Clients.Add(new Client { Name = "Client2", Email = "clientEmail2@email.com" });

        }
    }
}