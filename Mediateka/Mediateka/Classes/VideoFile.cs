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
            get
            {
                throw new NotImplementedException();
            }
        }

        public int[] Resolution
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }



        public VideoFile(string name, double size, string url) : base(name, size, url)
        {
        }

        
    }
}
