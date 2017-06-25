using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Context;
using Task5.DAL.Entities;
using Task5.DAL.Interfaces;

namespace Task5.DAL.Repositories
{
    public class ProductRepository : GenRepo<Product>
    {
        private readonly OrderContext _db;

        public ProductRepository(OrderContext context):base(context)
        {
            _db = context;
        }
    }
}
