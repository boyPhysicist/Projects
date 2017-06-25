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
        
        ProductDTO GetProduct(int? productId);
        ProductDTO GetProductByOrder(int orderId);
        ClientDTO GetClient(int? clientId);
        ClientDTO GetClientByOrder(int orderId);
        ManagerDTO GetManager(int? id);
        ManagerDTO GetManagerByOrder(int orderId);
        OrderDTO GetOrder(int? orderId);

        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<OrderDTO> GetOrders();
        IEnumerable<ManagerDTO> GetManagers();
        IEnumerable<ClientDTO> GetClients();
        IEnumerable<ClientDTO> GetClientsByProduct(int? productId);
        IEnumerable<OrderDTO> GetOrdersByManager(int? managerId);
        IEnumerable<OrderDTO> GetOrdersByClient(int? clientId);
        IEnumerable<OrderDTO> GetOrdersByProduct(int? productId);

        void MakeOrder(OrderDTO orderDto);
        void CreateManager(ManagerDTO manager);
        void CreateProduct(ProductDTO product);
        void CreateClient(ClientDTO client);
        void DeleteOrder(int orderId);
        void DeleteManager(int managerId);
        void DeleteProduct(int productId);
        void DeleteClient(int cliientId);
        void UpdateManager(ManagerDTO manager);
        void UpdateProduct(ProductDTO product);
        void UpdateClient(ClientDTO client);
        void UpdateOrder(OrderDTO order);



        void Dispose();

    }
}
