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
    public class ManagerRepository:IRepository<Manager>
    {
        private readonly OrderContext _db;

        public ManagerRepository(OrderContext context)
        {
            _db = context;
        }

        public void Create(Manager item)
        {
            _db.Managers.Add(item);
        }

        public void Delete(int id)
        {
            Manager item = _db.Managers.Find(id);
            if (item != null)
                _db.Managers.Remove(item);
        }

        public IEnumerable<Manager> Find(Func<Manager, bool> predicate)
        {
            return _db.Managers.Where(predicate).ToList();
        }

        public Manager Get(int id)
        {
            return _db.Managers.Find(id);
        }

        public IEnumerable<Manager> GetAll()
        {
            return _db.Managers;
        }

        public void Update(Manager item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
