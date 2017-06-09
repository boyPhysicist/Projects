using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public interface IRepository<DTO, Entity>:IDisposable
    {
        void Add(DTO obj);
        void Remove(DTO obj);
        void SaveChanges();
        Entity ToEntity(DTO source);
        void Update(DTO obj);
        Entity GetEntity(DTO source);
        Entity GetEntityNameById(int id);
        IEnumerable<DTO> Items { get; }
    }
}
