using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DAL.BufEnt
{
    public class BufManager
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public ICollection<BufSale> SalesSet { get; set; }
    }
}
