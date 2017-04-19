using Airline.Classes;
using Airline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Interfaces
{
    public interface ICompany
    {
        string CompanyName { get; }

        ICollection<IAirplanesModel> items { get; }
        
        void Add(AirplaneModel item);
        void SortByFlightRange();
        void ShowPlanes();

    }
}
