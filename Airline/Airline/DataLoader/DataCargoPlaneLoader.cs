using Airline.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.DataLoader
{
    public class DataCargoPlaneLoader : DataLoader
    {
        public override CargoPlane[] GetData(string filePath)
        {
            string _path = filePath;
            string[] temp = File.ReadAllLines(_path);

        }
    }
}
