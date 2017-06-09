using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public abstract class GeneralRepository<DTO, Entity, Context> : IRepository<DTO, Entity>
        where DTO : class
        where Context : System.Data.Entity.DbContext
        where Entity : class
    {
        protected Context _context;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Add(DTO obj)
        {
            // use automapper
            throw new NotImplementedException();
        }

        public void Remove(DTO obj)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Entity ToEntity(DTO source)
        {
            throw new NotImplementedException();
        }

        public void Update(DTO obj)
        {
            throw new NotImplementedException();
        }

        public Entity GetEntity(DTO source)
        {
            throw new NotImplementedException();
        }

        public Entity GetEntityNameById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTO> Items { get; }
    }
}
