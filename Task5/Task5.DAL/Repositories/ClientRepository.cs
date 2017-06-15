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
    public class ClientRepository : IRepository<Client>
    {
        private readonly OrderContext _db;

        public ClientRepository(OrderContext context)
        {
            _db = context;
        }

        public void Create(Client item)
        {
            _db.Clients.Add(item);
        }

        public void Delete(int id)
        {
            Client item = _db.Clients.Find(id);
            if (item != null)
                _db.Clients.Remove(item);
        }

        public IEnumerable<Client> Find(Func<Client, bool> predicate)
        {
            return _db.Clients.Where(predicate).ToList();
        }

        public Client Get(int id)
        {
            return _db.Clients.Find(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _db.Clients;
        }

        public void Update(Client item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
