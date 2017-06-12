using Task4;
using Task4.DAL.BuffModels;
using Task4.DAL.ContextFactory;
using Task4.DAL.Repo;
using Task4.Model;

namespace Task4_LastVersion_
{
    public class DbDataUpdater
    {
        private readonly IGenericDataRepo<BuffManager, ManagerSet> _managerRepo;
        private readonly IGenericDataRepo<BuffClient, ClientSet> _clientRepo;
        private readonly IGenericDataRepo<BuffProduct, ProductSet> _productRepo;
        private readonly IGenericDataRepo<BuffSale, SaleSet> _saleRepo;

        public DbDataUpdater()
        {
            _managerRepo = new ManagerRepo(new ContextFactory());
            _clientRepo=new ClientRepo(new ContextFactory());
            _productRepo = new ProductRepo(new ContextFactory());
            _saleRepo = new SaleRepo(new ContextFactory());
        }

        public void Add(SaleData data)
        {
            lock (this)
            {
                var newManager = new BuffManager { Name = data.ManagerName };
                var manager = _managerRepo.GetEntity(newManager, x => x.Name == newManager.Name);
                if (manager == null)
                {
                    _managerRepo.Add(newManager);
                    _managerRepo.SaveChanges();
                    manager = _managerRepo.GetEntity(newManager, x => x.Name == newManager.Name);
                }
               

                var newClient = new BuffClient { Name = data.ClientName };
                var client = _clientRepo.GetEntity(newClient, x => x.Name == newClient.Name);
                if (client == null)
                {
                    _clientRepo.Add(newClient);
                    _clientRepo.SaveChanges();
                    client = _clientRepo.GetEntity(newClient, x => x.Name == newClient.Name);
                }

                var newProduct = new BuffProduct {Name = data.ProductName, Cost = data.ProductCost };
                var product = _productRepo.GetEntity(newProduct, x => x.Name == newProduct.Name);

                if (product == null)
                {
                    _productRepo.Add(newProduct);
                    _productRepo.SaveChanges();
                    product = _productRepo.GetEntity(newProduct, x => x.Name == newProduct.Name);
                }

                if (manager != null)
                {
                    var saleInfo = new BuffSale
                    {
                        Date = data.Date,
                        Manager_Id = manager.Id,
                        Client_Id = client.Id,
                        Product_Id = product.Id
                    };
                    _saleRepo.Add(saleInfo);
                }
                _saleRepo.SaveChanges();
            }
        }

        
    }
}
