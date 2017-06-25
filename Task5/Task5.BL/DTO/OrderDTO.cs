using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.BL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime? Date { get; set; }

        //public int ProductId { get; set; }
        //public int ClientId { get; set; }
        //public int ManagerId { get; set; }

        public string ManagerName { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
    }
}
