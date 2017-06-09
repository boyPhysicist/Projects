using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DM;

namespace Task4.BL.Interfaces
{
    public interface IManagerBL
    {
        IList<ManagerSet> GetAllManagers();
        void AddManager(params ManagerSet[] managers);
        void RemoveManager(params ManagerSet[] managers);
        void UpdateManager(params ManagerSet[] managers);
    }
}
