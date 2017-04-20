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

        private ICollection<AirplaneModel> Items
        {
            get;
        }


        public AirCompany(string companyName)
        {
           
            CompanyName = companyName;

          Items = new List<AirplaneModel>();
        }
        public void Add(AirplaneModel item)
        {
            Items.Add(item);
            Console.WriteLine("Добавлен элемент {0}", item.Name + " " + item.Model);
        }

        public void ShowPlanes()
        {
            foreach (var item in Items)
            {
                Console.WriteLine(item.Name+" "+item.Model);
            }
        }

        public void SortByFlightRange()
        {
            
            if (Items != null)
            {
                var temp = Items.OrderBy(x => x.FlightRange).ToArray();
                Items.Clear();
                foreach(var item in temp)
                {
                    Items.Add(item);
                }
            }
            else
            {
                Console.WriteLine("There are no airplanes in this company.");
            }
             
        }

        public void ShowTypeOfPlane(int index)
        {
            Items.ElementAt(index).TypeOfPlane();
        }
        public void ShowTypeOfAllPlanes()
        {
            foreach(var item in Items)
            {
                item.TypeOfPlane();
            }
            
        }
        public void SearchByFuelConsumptionRange(double min, double max)
        {
            var q = Items.Where(x => x.FuelConsumptionLiterPerHour > min || x.FuelConsumptionLiterPerHour < max).Select(x => x.Name);
        }


    }
}
