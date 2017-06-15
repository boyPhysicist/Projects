using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Entities;

namespace Task5.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Client> Clients { get; }
        IRepository<Manager> Managers { get; }
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
