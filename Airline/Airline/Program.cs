using Airline.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class Program
    {
        static void Main(string[] args)
        {

            PassengerPlane PP = new PassengerPlane(135, 125, 125, 125, ",j,j", "700-300", 1222, 1000, 123, 123, 123, 123, 123, 123, 123, "xdfsxvc", 2, 123545, 128, SalonClasses.Economy);
            AirCompany AC = new AirCompany();
            AC.Add(PP);
        }
    }
}
