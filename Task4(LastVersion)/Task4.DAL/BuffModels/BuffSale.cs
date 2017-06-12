using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DAL.BuffModels
{
    public class BuffSale
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Product_Id { get; set; }
        public int Client_Id { get; set; }
        public int Manager_Id { get; set; }
    }
}
