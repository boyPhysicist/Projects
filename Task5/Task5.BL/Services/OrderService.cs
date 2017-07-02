using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Task5.BL.DTO;
using Task5.BL.Interfaces;
using Task5.DAL.Entities;
using Task5.DAL.Interfaces;


namespace Task5.BL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork DataBase { get; set; }
        private static void DtoToOrderObjAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderDTO, Product>()
                    .ForMember(x => x.Name, opt => opt.MapFrom(src => src.ProductName));
                cfg.CreateMap<OrderDTO, Manager>()
                    .ForMember(x => x.Name, opt => opt.MapFrom(src => src.ManagerName));
                cfg.CreateMap<OrderDTO, Client>()
                    .ForMember(x => x.Name, opt => opt.MapFrom(src => src.ClientName));
                cfg.CreateMap<OrderDTO, Order>()
                    .ForMember(x => x.Date, opt => opt.MapFrom(src => src.Date));
            });
        }
        public OrderService(IUnitOfWork unitOfWorkow)
        {
            DataBase = unitOfWorkow;
        }
        
        public IEnumerable<ManagerDTO> GetManagers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, ManagerDTO>());
            return Mapper.Map<IEnumerable<Manager>, List<ManagerDTO>>(DataBase.Managers.GetAll());
        }
        public ManagerDTO GetManager(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id менеджера", "");
            var manager = DataBase.Managers.Get(id.Value);
            if (manager == null)
                throw new ValidationException("Не найден менеджер", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, ManagerDTO>());

            return Mapper.Map<Manager, ManagerDTO>(manager);
        }
        public ManagerDTO GetManagerByOrder(int orderId)
        {
            return GetManager(DataBase.Orders.Get(orderId).ManagerId);
        }
        public void CreateManager(ManagerDTO manager)
        {
            if (manager == null)
                throw new ValidationException("Пустой объект", "CreateManager");
            Mapper.Initialize(cfg => cfg.CreateMap<ManagerDTO, Manager>());
            DataBase.Managers.Create(Mapper.Map<ManagerDTO, Manager>(manager));
            DataBase.Save();
        }
        public void DeleteManager(int managerId)
        {
            var orders = GetOrdersByManager(managerId);
            if (!orders.Any())
            {
                DataBase.Managers.Delete(managerId);
                DataBase.Save();
            }
            else
            {
                throw new ValidationException("За менеджером числится заказ", "");
            }
        }
        public void UpdateManager(ManagerDTO managerDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ManagerDTO, Manager>());
            var manager = Mapper.Map<ManagerDTO, Manager>(managerDto);
            DataBase.Managers.Update(manager);
            DataBase.Save();
        }

        public IEnumerable<OrderDTO> GetOrdersByProduct(int? productId)
        {
            var orders = GetOrders().Where(x => productId != null && x.ProductName == GetProduct(productId.Value).Name);
            return orders;
        }
        public IEnumerable<OrderDTO> GetOrdersByManager(int? id)
        {
            var orders = GetOrders().Where(x => id != null && x.ManagerName == GetManager(id.Value).Name);
            return orders;
        }
        public IEnumerable<OrderDTO> GetOrdersByClient(int? id)
        {
            var orders = GetOrders().Where(x => id != null && x.ClientName == GetClient(id.Value).Name);
            return orders;
        }
        public IEnumerable<OrderDTO> GetOrders()
        {
            var orders = DataBase.Orders.GetAll()
                .Include(x => x.Client)
                .Include(x => x.Manager)
                .Include(x => x.Product);
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDTO>());
            var orderDtos = Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orders);
            foreach (var item in orderDtos)
            {
                var firstOrDefault = orders.FirstOrDefault(x => x.Id == item.Id);
                if (firstOrDefault != null)
                {
                    item.ClientName = firstOrDefault.Client.Name;
                    item.ProductName = firstOrDefault.Product.Name;
                    item.ManagerName = firstOrDefault.Manager.Name;
                }
                
            }
            return orderDtos;
        }
        public OrderDTO GetOrder(int? orderId)
        {
            var orders = GetOrders();
            if (orderId == null)
                throw new ValidationException("Не установлено id заказа", "GetOrder");
            var order = orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
                throw new ValidationException("Не найден заказ", "GetOrder");
           return order;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            DtoToOrderObjAutoMapper();
            var order =Mapper.Map<OrderDTO, Order>(orderDto);
            var manager = DataBase.Managers.GetAll().FirstOrDefault(x => x.Name == orderDto.ManagerName);
            var product = DataBase.Products.GetAll().FirstOrDefault(x => x.Name == orderDto.ProductName);
            var client = DataBase.Clients.GetAll().FirstOrDefault(x => x.Name == orderDto.ClientName);
            if (client == null)
            {
                client = Mapper.Map<OrderDTO, Client>(orderDto);
                DataBase.Clients.Create(client);
            }
            if (manager == null)
            {
                manager = Mapper.Map<OrderDTO, Manager>(orderDto);
                DataBase.Managers.Create(manager);
            }
            order.Product = product ?? throw new ValidationException("Товар не найден!", "");
            order.Client = client;
            order.Manager = manager;
            order.Sum = order.Product.Price;
            DataBase.Orders.Create(order);
            DataBase.Save();
        }
        public void DeleteOrder(int orderId)
        {
            var order = DataBase.Orders.Get(orderId);
            if (order == null)
                throw new ValidationException("Заказ не найден", "");
            DataBase.Orders.Delete(order.Id);
            DataBase.Save();
        }
        public void UpdateOrder(OrderDTO orderDto)
        {
            DtoToOrderObjAutoMapper();
            var order = DataBase.Orders.Get(orderDto.Id);
            var manager = DataBase.Managers.GetAll().FirstOrDefault(x => x.Name == orderDto.ManagerName);
            var product = DataBase.Products.GetAll().FirstOrDefault(x => x.Name == orderDto.ProductName);
            var client = DataBase.Clients.GetAll().FirstOrDefault(x => x.Name == orderDto.ClientName);

            if (manager == null)
            {
                manager = Mapper.Map<OrderDTO, Manager>(orderDto);
                DataBase.Managers.Create(manager);
            }
            if (product == null)
            {
                product = Mapper.Map<OrderDTO, Product>(orderDto);
                DataBase.Products.Create(product);
            }
            if (client == null)
            {
                client = Mapper.Map<OrderDTO, Client>(orderDto);
                DataBase.Clients.Create(client);
            }
            if (orderDto.Date != null) order.Date = orderDto.Date;
            order.Product = product;
            order.Client = client;
            order.Manager = manager;
            DataBase.Orders.Update(order);
            DataBase.Save();
        }
        
        public IEnumerable<ClientDTO> GetClients()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, ClientDTO>());
            return Mapper.Map<IEnumerable<Client>, List<ClientDTO>>(DataBase.Clients.GetAll());
        }
        public IEnumerable<ClientDTO> GetClientsByProduct(int? productId)
        {
            var product = GetProduct(productId);
            var clientIds = DataBase.Orders.Find(x => x.ProductId == product.Id).Select(x => x.ClientId);
            List<ClientDTO> clients = new List<ClientDTO>();
            foreach (var id in clientIds)
            {
                clients.Add(GetClient(id));
            }
            return clients;
        }
        public ClientDTO GetClientByOrder(int orderId)
        {
            return GetClient(DataBase.Orders.Get(orderId).ClientId);
        }
        public ClientDTO GetClient(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id клиента", "");
            var client = DataBase.Clients.Get(id.Value);
            if (client == null)
                throw new ValidationException("Клиент не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Client, ClientDTO>());
            return Mapper.Map<Client, ClientDTO>(client);
        }
        public void CreateClient(ClientDTO client)
        {
            if (client == null)
                throw new ValidationException("Пустой объект", "Client creator");
            Mapper.Initialize(cfg => cfg.CreateMap<ClientDTO, Client>());
            DataBase.Clients.Create(Mapper.Map<ClientDTO, Client>(client));
            DataBase.Save();
        }
        public void UpdateClient(ClientDTO clientDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ClientDTO, Client>());
            var client = Mapper.Map<ClientDTO, Client>(clientDto);
            DataBase.Clients.Update(client);
            DataBase.Save();
        }
        public void DeleteClient(int clientId)
        {
            var orders = DataBase.Orders.Find(x => x.ClientId == clientId);
            if (!orders.Any())
            { 
                DataBase.Clients.Delete(clientId);
                DataBase.Save();
            }
            else
            {
                throw new ValidationException("У клиента есть заказы", "DeleteClient");
            }
            
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(DataBase.Products.GetAll());
        }
        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id товара", "");
            var product = DataBase.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Товар не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<Product, ProductDTO>(product);
        }
        public ProductDTO GetProductByOrder(int orderId)
        {
            return GetProduct(DataBase.Orders.Get(orderId).ProductId);
        }
        public void CreateProduct(ProductDTO product)
        {
            if (product == null)
                throw new ValidationException("Пустой объект", "CreateProduct");
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, Product>());
            DataBase.Products.Create(Mapper.Map<ProductDTO, Product>(product));
            DataBase.Save();
        }
        public void UpdateProduct(ProductDTO productDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, Product>());
            var product = Mapper.Map<ProductDTO, Product>(productDto);
            DataBase.Products.Update(product);
            DataBase.Save();
        }
        public void DeleteProduct(int productId)
        {
            var orders = DataBase.Orders.Find(x => x.ProductId == productId);
            if (!orders.Any())
            {
                DataBase.Products.Delete(productId);
                DataBase.Save();
            }
            else
            {
                throw new ValidationException("Продукт числится в заказе","DeleteProduct");
            }
            
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        

       

        

       

       

        

        

      
    }
}
