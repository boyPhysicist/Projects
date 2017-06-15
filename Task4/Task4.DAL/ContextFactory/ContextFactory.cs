using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DAL.ContextFactory
{
    public class ContextFactory:IContextFactory<SalesDBEntities>
    {
        public SalesDBEntities ContObj => new SalesDBEntities();
    }
}
