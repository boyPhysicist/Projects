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
    public class OrderRepository:IRepository<Order>
    {
        private readonly OrderContext _db;

        public OrderRepository(OrderContext context)
        {
            _db = context;
        }

        public void Create(Order item)
        {
            _db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order != null)
                _db.Orders.Remove(order);
            _db.SaveChanges();
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _db.Orders.Include(o => o.ProductId).Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return _db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders;
        }

        public void Update(Order item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
