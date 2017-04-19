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

            PassengerPlane PP = new PassengerPlane(135, 125, 125, 125, "111", "700-300", 1222, 1000, 123, 123, 123, 123, 123, 123, 123, "xdfsxvc", 2, 123545, 128, SalonClasses.Economy);
            PassengerPlane PP1 = new PassengerPlane(135, 125, 125, 125, "222", "700-300", 1222, 1000, 123, 123, 123, 123, 123, 123, 123, "xdfsxvc", 2, 123545, 128, SalonClasses.Economy);
            PassengerPlane PP2 = new PassengerPlane(135, 125, 125, 125, "333", "700-300", 1222, 1000, 123, 123, 123, 123, 123, 123, 123, "xdfsxvc", 2, 123545, 128, SalonClasses.Economy);
            PassengerPlane PP3 = new PassengerPlane(135, 125, 125, 125, "444", "700-300", 1222, 1000, 123, 123, 123, 123, 123, 123, 123, "xdfsxvc", 2, 123545, 128, SalonClasses.Economy);
            PassengerPlane PP4 = new PassengerPlane(135, 125, 125, 125, "555", "700-300", 1222, 1000, 123, 123, 123, 123, 123, 123, 123, "xdfsxvc", 2, 123545, 128, SalonClasses.Economy);
            AirCompany AC = new AirCompany("VB");
            AC.Add(PP);
            AC.Add(PP1);
            AC.Add(PP2);
            AC.Add(PP3);
            AC.Add(PP4);
            AC.ShowPlanes();

            Console.ReadLine();
        }
    }
}
