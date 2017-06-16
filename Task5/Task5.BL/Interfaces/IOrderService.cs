using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BL.DTO;

namespace Task5.BL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        ProductDTO GetProduct(int? id);
        ClientDTO GetClient(int? id);
        ManagerDTO GetManager(int? id);
        IEnumerable<ManagerDTO> GetManagers();
        IEnumerable<ClientDTO> GetClients();
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<OrderDTO> GetOrdersByClient(int? id);
        void Dispose();
    }
}
