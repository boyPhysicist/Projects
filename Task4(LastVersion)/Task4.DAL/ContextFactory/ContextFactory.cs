using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Model;

namespace Task4.DAL.ContextFactory
{
    public class ContextFactory : IContextFactory<SalesEntities>
    {
        public SalesEntities ContObj => new SalesEntities();
    }
    
}
