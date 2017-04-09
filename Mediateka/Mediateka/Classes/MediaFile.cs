
using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    public class MediaFile : IMediaFileItems
    {
        public string Name
        {
            get;
            protected set;
        }

        public double Size
        {
            get;
            
        }

        public string Url
        {
            get;
            
        }

        public MediaFile(string name, double size, string url)
        {
            Name = name;
            Size = size;
            Url = url;
        }
    }
}
