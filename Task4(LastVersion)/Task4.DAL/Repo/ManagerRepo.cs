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
    public class ManagerRepo : GenericDataRepo<BuffManager, ManagerSet, SalesEntities>
    {
        public ManagerRepo(IContextFactory<SalesEntities> factory) : base(factory)
        {
        }

        public override void Update(BuffManager obj)
        {
            var entity = _context.Set<ManagerSet>().FirstOrDefault(x => x.Name == obj.Name);
            if (entity != null)
            {
                entity.Name = obj.Name;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
