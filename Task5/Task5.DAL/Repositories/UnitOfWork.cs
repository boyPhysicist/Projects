using System;
using Task5.DAL.Context;
using Task5.DAL.Entities;
using Task5.DAL.Interfaces;

namespace Task5.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed=false;
        private readonly OrderContext _db;
        private ClientRepository _clientRepository;
        private ManagerRepository _managerRepository;
        private ProductRepository _productRepository;
        private OrderRepository _orderRepository;

        public UnitOfWork(string connectionString)
        {
            _db = new OrderContext(connectionString);
        }

        
        public IRepository<Client> Clients => _clientRepository 
            ?? (_clientRepository = new ClientRepository(_db));

        public IRepository<Manager> Managers => _managerRepository 
            ?? (_managerRepository = new ManagerRepository(_db));

        public IRepository<Product> Products => _productRepository 
            ?? (_productRepository = new ProductRepository(_db));

        public IRepository<Order> Orders => _orderRepository 
            ?? (_orderRepository = new OrderRepository(_db));


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
