using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    public class AudioFile : MediaFile, IBitRate, IType
    {
        public double BitPerSecond
        {
            get;
            
        }

        public string Type
        {
            get;
            
        }

        public double Time
        {
            get;

        }

       
        public AudioFile(string name, double size, string url, string author, double bitPerSecond, string type, double time) : base(name, size, url, author)
        {
            BitPerSecond = bitPerSecond;
            Type = type;
            Time = time;

        }

        
    }
}
