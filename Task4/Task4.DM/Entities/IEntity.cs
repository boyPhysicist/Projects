using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DM.Entities
{
    public interface IEntity
    {
        EntityState EntityState { get; set; }
    }
}
