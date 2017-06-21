﻿using System;
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
        public IEnumerable<OrderDTO> GetOrdersByManager(int? id)
        {
            var orders = DataBase.Orders.Find(x => x.ManagerId == GetManager(id).Id);
            if (orders == null)
                throw new ValidationException("Заказы не найдены", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDTO>());
            return Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orders);
        }
        public IEnumerable<OrderDTO> GetOrdersByClient(int? id)
        {
            var orders = DataBase.Orders.Find(x => x.ClientId == GetClient(id).Id);
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDTO>());
            return Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orders);
        }
        public IEnumerable<OrderDTO> GetOrders()
        {
            var orders = DataBase.Orders.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDTO>());
            return Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orders);
        }
        public IEnumerable<ProductDTO> GetProducts()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(DataBase.Products.GetAll());
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
        public ManagerDTO GetManagerByOrder(int? orderId)
        {
            return GetManager(GetOrder(orderId).ManagerId);
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
            return GetProduct(GetOrder(orderId).ProductId);
        }
        public OrderDTO GetOrder(int? orderId)
        {
            if (orderId == null)
                throw new ValidationException("Не установлено id заказа", "GetOrder");
            var order = DataBase.Orders.Get(orderId.Value);
            if (order == null)
                throw new ValidationException("Не найден заказ", "GetOrder");
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDTO>());

            return Mapper.Map<Order, OrderDTO>(order);
        }

        public void DeleteOrder(int orderId)
        {
            var order = DataBase.Orders.Get(orderId);
            if(order==null)
                throw new ValidationException("Заказ не найден","");
            DataBase.Orders.Delete(order.Id);
        }
        public ClientDTO GetClientByOrder(int? orderId)
        {
            return GetClient(GetOrder(orderId).ClientId);
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

        public void CreateManager(ManagerDTO manager)
        {
            if (manager==null)
                throw new ValidationException("Пустой объект", "CreateManager");
            Mapper.Initialize(cfg=>cfg.CreateMap<ManagerDTO,Manager>());
            DataBase.Managers.Create(Mapper.Map<ManagerDTO,Manager>(manager));
            DataBase.Save();
        }
        public void CreateProduct(ProductDTO product)
        {
            if (product == null)
                throw new ValidationException("Пустой объект", "CreateProduct");
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, Product>());
            DataBase.Products.Create(Mapper.Map<ProductDTO, Product>(product));
            DataBase.Save();
        }
        public void CreateClient(ClientDTO client)
        {
            if (client == null)
                throw new ValidationException("Пустой объект", "Client creator");
            Mapper.Initialize(cfg => cfg.CreateMap<ClientDTO, Client>());
            DataBase.Clients.Create(Mapper.Map<ClientDTO, Client>(client));
            DataBase.Save();
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Product product = DataBase.Products.Get(orderDto.ProductId);

            if (product == null)
                throw new ValidationException("Товар не найден!", "MakeOrder");
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
        public void Dispose()
        {
            DataBase.Dispose();
        }

    }
}
