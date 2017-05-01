using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.Classes;
using System.IO;

namespace Airline.DataLoader
{
    public class DataPasengerPlaneLoader : DataLoader
    {
        public override AirCompany GetData(string filePath, AirCompany aC)
        {
            string _path = filePath;
            string[] temp = File.ReadAllLines(_path);
            char _delimiterChar = ';';
            PassengerPlane[] CP = new PassengerPlane[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                string[] words = temp[i].Split(_delimiterChar);
                if (words.Length == 20)
                {
                    SalonClasses SC;
                         
                    string chars = words[19];
                    if (Enum.TryParse(chars, out SC))
                    {
                        var a = new PassengerPlane(words[0], words[1], Convert.ToDouble(words[2]), Convert.ToDouble(words[3]),
                            Convert.ToDouble(words[4]), Convert.ToDouble(words[5]), Convert.ToDouble(words[6]), Convert.ToDouble(words[7]),
                            Convert.ToDouble(words[8]), Convert.ToDouble(words[9]), Convert.ToDouble(words[10]), Convert.ToDouble(words[11]),
                            Convert.ToDouble(words[12]), Convert.ToDouble(words[13]), Convert.ToDouble(words[14]), Convert.ToDouble(words[15]),
                            words[16], Convert.ToInt32(words[17]), Convert.ToInt32(words[18]), SC);
                        CP[i] = a;
                    }
                    else
                    {
                        Console.WriteLine("Error!!!(SalonClasses)");
                    }
                }
                else
                {
                    Console.WriteLine("Error(Upload data)");
                }

                
            }
            for (int j = 0; j < CP.Length; j++)
            {
                aC.Add(CP[j]);
            }
            return aC;
        }
    }
}
