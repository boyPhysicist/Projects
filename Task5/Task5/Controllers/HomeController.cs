using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Task5.BL;
using Task5.BL.DTO;
using Task5.BL.Interfaces;
using Task5.Models;

namespace Task5.Controllers
{
    public class HomeController : Controller
    {
        readonly IOrderService _orderService;
        public HomeController(IOrderService serv)
        {
            _orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<ProductDTO> productDtos = _orderService.GetProducts();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductView>());
            var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductView>>(productDtos);
            ViewBag.Products = products;
            return View();
        }

       
        public ActionResult Managers()
        {
            IEnumerable<ManagerDTO> managerDtos = _orderService.GetManagers();
            Mapper.Initialize(cfg => cfg.CreateMap<ManagerDTO, ManagerView>());
            var managers = Mapper.Map<IEnumerable<ManagerDTO>, List<ManagerView>>(managerDtos);
            return PartialView(managers);
        }


        public ActionResult Clients()
        {
            IEnumerable<ClientDTO> clientDtos = _orderService.GetClients();
            Mapper.Initialize(cfg => cfg.CreateMap<ClientDTO, ClientView>());
            var clients = Mapper.Map<IEnumerable<ClientDTO>, List<ClientView>>(clientDtos);
            return PartialView(clients);
        }

        public ActionResult Orders()
        {
            IEnumerable<OrderDTO> orderDtos = _orderService.GetOrders();
            Mapper.Initialize(cfg => cfg.CreateMap<OrderDTO, OrderView>());
            var orders = Mapper.Map<IEnumerable<OrderDTO>, List<OrderView>>(orderDtos);
            return PartialView(orders);

        }

        public ActionResult DeleteOrder(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                IEnumerable<OrderDTO> orderDtos = _orderService.GetOrders();
                Mapper.Initialize(cfg => cfg.CreateMap<OrderDTO, OrderView>());
                var orders = Mapper.Map<IEnumerable<OrderDTO>, List<OrderView>>(orderDtos);
                return Index();
            }
            catch (ValidationException e)
            {
                return ErrorHandler(e);
            }
            
        }

        public ActionResult ErrorHandler(ValidationException ex)
        {
            return View(ex);
        }
        
        [HttpGet]
        public ActionResult MakeOrder()
        {
            //ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public string MakeOrder(OrderView order)
        {
            order.Date = DateTime.Now;
            Mapper.Initialize(cfg => cfg.CreateMap<OrderView, OrderDTO>());
            _orderService.MakeOrder(Mapper.Map<OrderView, OrderDTO>(order));
            return "Vse GooD!!!";
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}