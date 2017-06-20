using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
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
            IEnumerable<ClientDTO> managerDtos = _orderService.GetClients();
            Mapper.Initialize(cfg => cfg.CreateMap<ClientDTO, ClientView>());
            var clients = Mapper.Map<IEnumerable<ClientDTO>, List<ClientView>>(managerDtos);


            return PartialView(clients);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}