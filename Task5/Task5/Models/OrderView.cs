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

        public string ManagerName { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
    }
}