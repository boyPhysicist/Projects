using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }

        public Product Product { get; set; }
        public Client Client { get; set; }
        public Manager Manager { get; set; }

        
    }
}
