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
        public override AirplaneModel[] GetData(string filePath)
        {
            string _path = filePath;
            string[] temp = File.ReadAllLines(_path);
            char _delimiterChar = ';';
            CargoPlane[] CP=new CargoPlane[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                string[] words = temp[i].Split(_delimiterChar);
                if(words.Length == 18)
                {
                    

                    var a = new CargoPlane(words[0], words[1], Convert.ToDouble(words[2]), Convert.ToDouble(words[3]),
                        Convert.ToDouble(words[4]), Convert.ToDouble(words[5]), Convert.ToDouble(words[6]), Convert.ToDouble(words[7]),
                        Convert.ToDouble(words[8]), Convert.ToDouble(words[9]), Convert.ToDouble(words[10]), Convert.ToDouble(words[11]),
                        Convert.ToDouble(words[12]), Convert.ToDouble(words[13]), Convert.ToDouble(words[14]), Convert.ToDouble(words[15]),
                        words[16], Convert.ToInt32(words[17]));

                    CP[i] = a;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }

            return CP;
        }
    }
}
