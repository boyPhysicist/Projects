using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;

namespace Task4.DAL
{
    public static class DbContextExtensions
    {
        public static ObjectContext ToObjectContext(this DbContext dbContext)
        {
            return (dbContext as IObjectContextAdapter).ObjectContext;
        }
    }
}
