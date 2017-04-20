using Airline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Classes
{
    public abstract class AirplaneModel 
    {
        public abstract double Height { get; }
        public abstract double Length { get;}
        public abstract double WingArea {get;}
        public abstract double WingSpan {get;}
        public abstract string Name { get;}
        public abstract string Model { get; }
        public abstract double FuelConsumptionLiterPerHour { get;}
        public abstract double FlightRange { get; }


    }
}
