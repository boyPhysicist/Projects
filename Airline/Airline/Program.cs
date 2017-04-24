using Airline.Classes;
using Airline.DataLoader;
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

            CargoPlane CP = new CargoPlane("Samoletik", "b171", 10, 35, 25, 17, 17000, 23000, 100000, 123123, 1231234, 123235434, 321321, 214345, 12334, 23435, "hjhjdhj", 4);
            CargoPlane CP1 = new CargoPlane("Samoletik1", "b172", 102, 352, 252, 172, 170002, 230002, 1000002, 1231232, 12312342, 1232354342, 3213212, 2143452, 123342, 234352, "hjhjdhj", 4);
            CargoPlane CP2 = new CargoPlane("Samoletik2", "b173", 1022, 3522, 2522, 1722, 1700022, 2300022, 10000022, 12312322, 123123422, 12323543422, 32132122, 21434522, 1233422, 2343522, "hjhjdhj", 4);
            PassengerPlane PP = new PassengerPlane("Samoletik1", "b172", 102, 352, 252, 172, 170002, 230002, 1000002, 1231232, 12312342, 1232354342, 3213212, 2143452, 123342, 234352, "hjhjdhj", 4, 128, SalonClasses.Business | SalonClasses.Economy);
            PassengerPlane PP1 = new PassengerPlane("Samoletik2", "b173", 1022, 3522, 2522, 1722, 1700022, 2300022, 10000022, 12312322, 123123422, 12323543422, 32132122, 21434522, 1233422, 2343522, "hjhjdhj", 4, 128, SalonClasses.Business | SalonClasses.Economy);
            PassengerPlane PP2 = new PassengerPlane("Samoletik", "b171", 10, 35, 25, 17, 17000, 23000, 100000, 123123, 1231234, 123235434, 321321, 214345, 12334, 23435, "hjhjdhj", 4, 128, SalonClasses.Business | SalonClasses.Economy);

            AirCompany AC = new AirCompany("BritishAirlanes");
            DataCargoPlaneLoader DL = new DataCargoPlaneLoader();

            //AC.Add(CP);
            //AC.Add(CP1);
            //AC.Add(CP2);
            //AC.Add(PP);
            //AC.Add(PP1);
            //AC.Add(PP2);
            //AC.ShowPlanes();
            //AC.SortByFlightRange();
            //AC.ShowPlanes();
            //AC.ShowTypeOfPlane(0);
            AirplaneModel[] a = DL.GetData(@"C:\Users\Philip.SHOP\Source\Repos\Projects\Airline\Airline\Files\CargoData.txt");
            for(int i = 0; i < a.Length; i++)
            {
                AC.Add(a[i]);
            }
            AC.ShowPlanes();
            //AC.Add(new SpecialPlane());





            Console.ReadLine();
        }
    }
}
