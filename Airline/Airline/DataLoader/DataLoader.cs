using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.DataLoader
{
    public abstract class DataLoader
    {
        public string FilePath { get; }
        public abstract void GetData(string filePath);
    }
}
