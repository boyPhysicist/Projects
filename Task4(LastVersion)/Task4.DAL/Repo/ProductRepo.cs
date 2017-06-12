using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DAL.BuffModels;
using Task4.DAL.ContextFactory;
using Task4.Model;

namespace Task4.DAL.Repo
{
    public class ProductRepo:GenericDataRepo<BuffProduct,ProductSet, SalesEntities>
    {
        public ProductRepo(IContextFactory<SalesEntities> factory) : base(factory)
        {
        }

        public override void Update(BuffProduct obj)
        {
            var entity = _context.Set<ProductSet>().FirstOrDefault(x => x.Name == obj.Name);
            if (entity != null)
            {
                entity.Name = obj.Name;
                entity.Coast = obj.Coast;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
