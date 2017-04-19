using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Classes
{
    class SpecialPlane : AirplaneModel
    {
        public SpecialPlane(double height, double lenght, double wingArea, double wingSpan, string name, string model) 
            : base(height, lenght, wingArea, wingSpan, name, model)
        {
        }
    }
}
