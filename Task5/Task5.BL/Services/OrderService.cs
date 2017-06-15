using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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

    }
}
