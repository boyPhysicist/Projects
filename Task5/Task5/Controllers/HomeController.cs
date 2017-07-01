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
        private readonly IOrderService _orderService;
        public HomeController(IOrderService serv)
        {
            _orderService = serv;
        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Products()
        {
            var productDtos = _orderService.GetProducts();
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductView>());
            var products = Mapper.Map<IEnumerable<ProductDTO>, List<ProductView>>(productDtos);
            return View(products);
        }
        [Authorize]
        public ActionResult Managers()
        {
            var managersDtos = _orderService.GetManagers();
            Mapper.Initialize(cfg => cfg.CreateMap<ManagerDTO, ManagerView>());
            var managers = Mapper.Map<IEnumerable<ManagerDTO>, List<ManagerView>>(managersDtos);
            return View(managers);
        }
        [Authorize]
        public ActionResult Clients()
        {
            var clientDtos = _orderService.GetClients();
            Mapper.Initialize(cfg => cfg.CreateMap<ClientDTO, ClientView>());
            var clients = Mapper.Map<IEnumerable<ClientDTO>, List<ClientView>>(clientDtos);
            return View(clients);
        }
        [Authorize]
        public ActionResult Orders()
        {
            var orders = _orderService.GetOrders();
            Mapper.Initialize(cfg=>cfg.CreateMap<OrderDTO,OrderView>());
            
            return View(Mapper.Map<IEnumerable<OrderDTO>,List<OrderView>>(orders));
        }
        public ActionResult ErrorHandler(ValidationException ex)
        {
            return View(ex);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateOrder()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateOrder(OrderView order)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<OrderView,OrderDTO>());
            order.Date = DateTime.Now;
            _orderService.MakeOrder(Mapper.Map<OrderView,OrderDTO>(order));
            return Redirect("Index");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return Index();
            }
            catch (ValidationException e)
            {
                return View(e);
            }
           
            
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult UpdateOrder(int id)
        {
            try
            {
                var orderDto = _orderService.GetOrder(id);
                Mapper.Initialize(cfg => cfg.CreateMap<OrderDTO, OrderView>());
                var order = Mapper.Map<OrderDTO, OrderView>(orderDto);
                return View(order);
            }
            catch (ValidationException e)
            {
                return ErrorHandler(e);
            }

        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult UpdateOrder(OrderView order)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OrderView, OrderDTO>());
            _orderService.UpdateOrder(Mapper.Map<OrderView, OrderDTO>(order));
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateManager()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateManager(ManagerView managerView)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ManagerView, ManagerDTO>());
            _orderService.CreateManager(Mapper.Map<ManagerView,ManagerDTO>(managerView));
            return Redirect("Index");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteManager(int id)
        {
            try
            {
                _orderService.DeleteManager(id);
                return View();
            }
            catch (ValidationException e)
            {
                return ErrorHandler(e);
            }


        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult UpdateManager(int id)
        {
            try
            {
                var managerDto = _orderService.GetManager(id);
                Mapper.Initialize(cfg => cfg.CreateMap<ManagerDTO, ManagerView>());
                var manager = Mapper.Map<ManagerDTO, ManagerView>(managerDto);
                return View(manager);
            }
            catch (ValidationException e)
            {
                return ErrorHandler(e);
            }

        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult UpdateManager(ManagerView manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ManagerView, ManagerDTO>());
            _orderService.UpdateManager(Mapper.Map<ManagerView, ManagerDTO>(manager));
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateClient()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateClient(ClientView client)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<ClientView,ClientDTO>());
            _orderService.CreateClient(Mapper.Map<ClientView,ClientDTO>(client));
            return Redirect("Index");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteClient(int id)
        {
            try
            {
                _orderService.DeleteClient(id);
                return View();
            }
            catch (ValidationException e)
            {
                return View(e);
            }


        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult UpdateClient(int id)
        {
            try
            {
                var clientDto = _orderService.GetClient(id);
                Mapper.Initialize(cfg => cfg.CreateMap<ClientDTO, ClientView>());
                var client = Mapper.Map<ClientDTO, ClientView>(clientDto);
                return View(client);
            }
            catch (ValidationException e)
            {
                return ErrorHandler(e);
            }
            
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult UpdateClient(ClientView client)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<ClientView,ClientDTO>());
            _orderService.UpdateClient(Mapper.Map<ClientView,ClientDTO>(client));
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateProduct(ProductView product)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<ProductView,ProductDTO>());
            _orderService.CreateProduct(Mapper.Map<ProductView,ProductDTO>(product));
            return Redirect("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                _orderService.DeleteProduct(id);
                return View();
            }
            catch (ValidationException e)
            {
                return View(e);
            }


        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            try
            {
                var productDto = _orderService.GetProduct(id);
                Mapper.Initialize(cfg => cfg.CreateMap<ProductDTO, ProductView>());
                var product = Mapper.Map<ProductDTO, ProductView>(productDto);
                return View(product);
            }
            catch (ValidationException e)
            {
                return ErrorHandler(e);
            }

        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult UpdateProduct(ProductView product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductView, ProductDTO>());
            _orderService.UpdateProduct(Mapper.Map<ProductView, ProductDTO>(product));
            return View();
        }

        public JsonResult Chart()
        {
            var list = GetData();
            return Json(new { Orders = list }, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<Data> GetData()
        {
            IEnumerable<OrderDTO> orderDtos = _orderService.GetOrders();
            Mapper.Initialize(cfg => cfg.CreateMap<OrderDTO, OrderView>());
            var result = Mapper.Map<IEnumerable<OrderDTO>, List<OrderView>>(orderDtos);
            var data = result.GroupBy(x => x.ManagerName).Select(y => new Data
            {
                ManagerId = y.Key,
                CountClients = y.Select(m => m.ClientName).Distinct().Count()
            }).ToList();
            return data;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sort(string manager, string product,string client, string date)
        {
            var orders = _orderService.GetOrders();
            var managers = orders.Select(x => x.ManagerName).Distinct().ToList();
            managers.Insert(0, "All");
            var products = orders.Select(x => x.ProductName).Distinct().ToList();
            products.Insert(0, "All");
            var clients = orders.Select(x => x.ClientName).Distinct().ToList();
            clients.Insert(0, "All");
            var dates = orders.Select(x => x.Date.ToString()).Distinct().ToList();
            dates.Insert(0, "All");

            if (!string.IsNullOrEmpty(manager) && !manager.Equals("All"))
            {
                orders = orders.Where(x => x.ManagerName == manager);
            }

            if (!string.IsNullOrEmpty(product) && !product.Equals("All"))
            {
                orders = orders.Where(x => x.ProductName == product);
            }

            if (!string.IsNullOrEmpty(client) && !client.Equals("All"))
            {
                orders = orders.Where(x => x.ClientName == client);
            }

            if (!string.IsNullOrEmpty(date) && !date.Equals("All"))
            {
                orders = orders.Where(x => x.Date.ToString() == date);
            }
            var info = new InfoView
            {
                Orders = orders,
                Managers = new SelectList(managers),
                Products = new SelectList(products),
                Clients = new SelectList(clients),
                Dates = new SelectList(dates)
            };

            return View(info);
        }
    }
}