using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DAL.BufEnt
{
    public class BufClient
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public ICollection<BufSale> SalesSet { get; set; }
    }
}
