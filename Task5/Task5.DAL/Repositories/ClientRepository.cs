﻿using System;
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
    public class ClientRepository : GenRepo<Client>
    {
        
        public ClientRepository(OrderContext context):base (context)
        {
            
        }

        
    }
}
