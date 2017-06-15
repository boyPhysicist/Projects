using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DAL.BuffModels
{
    public class BuffProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coast { get; set; }
        public ICollection<BuffSale> SaleSet{ get; set; }
    }
}
