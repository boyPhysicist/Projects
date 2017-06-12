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
    public class ClientRepo:GenericDataRepo<BuffClient, ClientSet, SalesEntities>
    {
     

        public override void Update(BuffClient obj)
        {
            var entity = _context.Set<ClientSet>().FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                entity.Name = obj.Name;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public ClientRepo(IContextFactory<SalesEntities> factory) : base(factory)
        {
        }
    }
   
}
