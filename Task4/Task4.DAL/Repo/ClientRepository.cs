﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DAL.BufEnt;
using Task4.DAL.ContextFactory;
using Task4.DAL.Repo.Interfaces;
using Task4.DM;

namespace Task4.DAL.Repo
{
    public class ClientRepository:GenericDataRepository<BufClient, ClientSet, SalesDBEntities>
    {
        public ClientRepository(IContextFactory<SalesDBEntities> factory) : base(factory)
        {
        }

        public override void Update(BufClient obj)
        {
            var entity = _context.Set<ClientSet>().FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                entity.ClientName = obj.ClientName;
            }
            else
            {
                //Add try/catch
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
