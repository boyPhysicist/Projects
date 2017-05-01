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

        private ICollection<AirplaneModel> Items;
       
        public AirCompany(string companyName, ICollection<AirplaneModel> items)
        {
           
            CompanyName = companyName;
            Items = items;
        }
        public void Add(AirplaneModel item)
        {
            Items.Add(item);
        }

        public string[] GiveInfoForShowPlanes()
        {
            int i = 0;
            string[] temp = new string[Items.Count];
            foreach (var item in Items)
            {
                temp[i] = item.Name + " " + item.Model;
                i += 1;
            }
            return temp;
        }

        public AirplaneModel[] SortByFlightRange()
        {
            
            if (Items != null)
            {
                var temp = Items.OrderBy(x => x.FlightRange).ToArray();
                return temp;
            }
            else
            {
                return null;
            }

        }

        public string GetTypeOfPlane(int index)
        {
           return Items.ElementAt(index).GetTypeOfPlane();
        }
        public int GetPassengerСapacity()
        {
            int ps = 0;
            foreach(var item in Items)
            {
                ps = ps + item.GetPassengerСapacity();
            }
            return(ps);
        }
        public void GetTypesOfAllPlanes()
        {
            foreach(var item in Items)
            {
                item.GetTypeOfPlane();
            }
            
        }
        public IEnumerable<string> SearchByFuelConsumptionRange(double min, double max)
        {
            var q = Items.Where(x => x.FuelConsumptionLiterPerHour > min & x.FuelConsumptionLiterPerHour < max).Select(x => x.GetPlane()+" "+x.FuelConsumptionLiterPerHour);
            return q;
        }

        public double GetCarryingCapacity()
        {
            double temp = 0;
            foreach(var item in Items)
            {
                temp = temp + item.GetCarryingCapacity();
            }
            return temp;
        }

        public void DeletePlane(int number)
        {
            var item = Items.ElementAt(number);


            Items.Remove(item);
            
        }
        public void DeletePlane(AirplaneModel model)
        {
            Items.Remove(model);
        }
        
    }
}
