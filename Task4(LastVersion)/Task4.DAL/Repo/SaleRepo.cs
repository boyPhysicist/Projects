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
    public class SaleRepo : GenericDataRepo<BuffSale, SaleSet, SalesEntities>
    {
        public SaleRepo(IContextFactory<SalesEntities> factory) : base(factory)
        {
        }

        public override void Update(BuffSale obj)
        {
            var entity = _context.Set<SaleSet>().FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                entity.Date = obj.Date;
                entity.Manager_Id = obj.Manager_Id;
                entity.Client_Id = obj.Client_Id;
                entity.Product_Id = obj.Product_Id;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
