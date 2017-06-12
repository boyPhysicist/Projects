using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DM.Entities;

namespace Task4.DM
{
    public partial class ClientSet : IEntity
    {
        public EntityState EntityState { get; set; }
    }
}
