using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DAL.Repo.Interfaces;
using Task4.DM;

namespace Task4.DAL.Repo
{
    public class ClientRepository:GenericDataRepository<ClientSet>, IClientRepository
    {
    }
}
