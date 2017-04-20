using Airline.Classes;
using Airline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Classes
{
    public class AirCompany : ICompany
    {
      
        public string CompanyName
        {
            get;
        }

        public ICollection<IAirplanesModel> Items
        {
            get;
        }


        public AirCompany(string companyName)
        {
           
            CompanyName = companyName;

          Items = new List<IAirplanesModel>();
        }
        public void Add(AirplaneModel item)
        {
            Items.Add(item);
            Console.WriteLine("Добавлен элемент {0}", item.Name + " " + item.Model);
        }

        public void ShowPlanes()
        {
            foreach (AirplaneModel item in Items)
            {
                Console.WriteLine(item.Name+" "+item.Model);
            }
        }

        public void SortByFlightRange()
        {
            // temp1.OrderBy(x => x.FlightRange).ToArray();

            

           

        }


        

    }
}
