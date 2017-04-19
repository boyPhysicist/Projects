﻿using Airline.Classes;
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
        //public string CompanyName
        //{
        //    get;
        //}

        //public ICollection<IAirplaneModel> items
        //{
        //    get;
        //}

        //ICollection<IAirplanesModel> ICompany.items
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public AirCompany()
        //{
        //    items = new List<IAirplaneModel>();
        //}
        //public void Add(AirplaneModel airplane)
        //{
        //    items.Add(airplane);
        //}

        //public void ShowPlanes()
        //{
        //   foreach (var item in items)
        //    {
        //        Console.WriteLine(item.Name);
        //    }
        //}

        //public void SortByFlightRange()
        //{
        //    var x = items.OrderBy(x=>x.FlightRange)
        //}
        public string CompanyName
        {
            get;
        }

        public ICollection<IAirplanesModel> items
        {
            get;
        }


        public AirCompany()
        {
            ICollection<IAirplanesModel> items = new List<IAirplanesModel>();
        }
        public void Add(AirplaneModel item)
        {
            items.Add(item);
            Console.WriteLine("Добавлен элемент {0}", item.Name + " " + item.Model);
        }

        public void ShowPlanes()
        {
            throw new NotImplementedException();
        }

        public void SortByFlightRange()
        {
            throw new NotImplementedException();
        }


        

    }
}
