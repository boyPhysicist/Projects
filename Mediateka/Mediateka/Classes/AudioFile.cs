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

        
        public AudioFile(string name, double size, string url, string author, double bitPerSecond, string type) : base(name, size, url, author)
        {
            BitPerSecond = bitPerSecond;
            Type = type;

        }

        
    }
}
