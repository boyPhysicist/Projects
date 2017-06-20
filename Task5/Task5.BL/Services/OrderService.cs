using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
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
            if(manager==null)
                throw new ValidationException("Не найден менеджер", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Manager, ManagerDTO>());

            return Mapper.Map<Manager, ManagerDTO>(manager);
        }

        public void CreateManager(ManagerDTO manager)
        {
            if (manager==null)
                throw new ValidationException("Пустой объект","");
            Mapper.Initialize(cfg=>cfg.CreateMap<ManagerDTO,Manager>());
            DataBase.Managers.Create(Mapper.Map<ManagerDTO,Manager>(manager));
            DataBase.Save();
        }

        public void CreateProduct(ProductDTO product)
        {
            if (product == null)
                throw new ValidationException("Пустой объект", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, Product>());
            DataBase.Products.Create(Mapper.Map<ProductDTO, Product>(product));
            DataBase.Save();
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

        public ProductDTO GetProductByOrder(int? orderId)
        {
            var order = GetOrder(orderId);
            Mapper.Initialize(cfg=>cfg.CreateMap<Product,ProductDTO>());
            return Mapper.Map<Product, ProductDTO>(DataBase.Products.Get(order.ClientId));
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(DataBase.Products.GetAll());
        }

        public void MakeOrder(OrderDTO orderDto)
        {
            Product product = DataBase.Products.Get(orderDto.ProductId);

            if(product==null)
                throw new ValidationException("Товар не найден!","");
            Order order = new Order
            {
                ClientId = orderDto.ClientId,
                Date = DateTime.Now,
                ManagerId = orderDto.ManagerId,
                ProductId = product.Id,
                Sum = product.Price
            };
            DataBase.Orders.Create(order);
            DataBase.Save();
        }

        public OrderDTO GetOrder(int? orderId)
        {
            if (orderId == null)
                throw new ValidationException("Не установлено id заказа", "GetOrder");
            var order = DataBase.Orders.Get(orderId.Value);
            if (order == null)
                throw new ValidationException("Не найден заказ", "GetOrder");
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDTO>());

            return Mapper.Map<Order,OrderDTO>(order);
        }

        public IEnumerable<OrderDTO> GetOrdersByClient(int? id)
        {
            var client = GetClient(id);
            var orders = DataBase.Orders.Find(x => x.ClientId == client.Id);
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDTO>());
            return Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orders);
        }

        public IEnumerable<OrderDTO> GetOrdersByManager(int? id)
        {
            var manager = GetManager(id);
            var orders = DataBase.Orders.Find(x => x.ManagerId == manager.Id);
            if(orders==null)
                throw new ValidationException("Заказы не найдены", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDTO>());
            return Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orders);
        }

        public void CreateClient(ClientDTO client)
        {
            if (client == null)
                throw new ValidationException("Пустой объект", "Client creator");
            Mapper.Initialize(cfg => cfg.CreateMap<ClientDTO, Client>());
            DataBase.Clients.Create(Mapper.Map<ClientDTO, Client>(client));
            DataBase.Save();
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

        public IEnumerable<ClientDTO> GetClients()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, ClientDTO>());
            return Mapper.Map<IEnumerable<Client>, List<ClientDTO>>(DataBase.Clients.GetAll());
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
 
        public ClientDTO GetClientByOrder(int? orderId)
        {
            throw new NotImplementedException();
        }

        public ManagerDTO GetManagerByOrder(int? orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientDTO> GetClientsByProduct(int? productId)
        {
            var product = GetProduct(productId);
            var clientIds = DataBase.Orders.Find(x => x.ProductId == product.Id).Select(x=>x.ClientId);
            List<ClientDTO> clients=new List<ClientDTO>();
            foreach (var id in clientIds)
            {
                clients.Add(GetClient(id));
            }
            return clients;
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<Order,OrderDTO>());
            return Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(DataBase.Orders.GetAll());
        }

        
    }
}
