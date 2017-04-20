using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Classes
{
    class SpecialPlane : AirplaneModel
    {
        public override double FlightRange
        {
            get

            {
                Console.WriteLine("This is model. It does not fly.");
                return 0;
            }
        }

        public override double FuelConsumptionLiterPerHour
        {
            get
            {
                Console.WriteLine("This is model. It does not fly.");
                return 0;
            }
        }

        public override double Height
        {
            get;
        }

        public override double Length
        {
            get;
        }

        public override string Model
        {
            get;
        }

        public override string Name
        {
            get;
        }

        public override double WingArea
        {
            get;
        }

        public override double WingSpan
        {
            get;
        }

        public override void TypeOfPlane()
        {
            Console.WriteLine("This is model.");
        }
    }
}
