using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    public class VideoFile : MediaFile, IBitRate, IResolution, IType
    {

        public double BitPerSecond
        {
            get;
        }

        public int[] Resolution
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

        public VideoFile(string name, double size, string url, string author, double bitPerSecond, int[] resolution, string type, double time ) : base(name, size, url, author)
        {
            Resolution = resolution;
            BitPerSecond = bitPerSecond;
            Type = type;
            Time = time;
        }

        
    }
}
