using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task5.Models
{
    public class OrderView
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }
    }
}