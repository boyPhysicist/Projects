using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Context;
using Task5.DAL.Entities;
using Task5.DAL.Interfaces;

namespace Task5.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly OrderContext _db;

        public ProductRepository(OrderContext context)
        {
            _db = context;
        }

        public void Create(Product item)
        {
            _db.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product item = _db.Products.Find(id);
            if (item != null)
                _db.Products.Remove(item);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _db.Products.Where(predicate).ToList();
        }

        public Product Get(int id)
        {
           return _db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products;
        }

        public void Update(Product item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
