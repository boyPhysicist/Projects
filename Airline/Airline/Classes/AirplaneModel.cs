using Airline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Classes
{
    public class AirplaneModel : IAirplanesModel
    {
        public double Height
        {
            get;
            
        }

        public double Length
        {
            get;
        }

        public double WingArea
        {
            get;
        }

        public double WingSpan
        {
            get;
        }

        public string Name { get; }
        public string Model { get; }

        public AirplaneModel(double height, double lenght, double wingArea, double wingSpan, string name, string model )
        {
            Height = height;
            Length = lenght;
            WingArea = wingArea;
            WingSpan = wingSpan;
            Name = name;
            Model = model;
        }
    }
}
