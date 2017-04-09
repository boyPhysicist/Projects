
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

        public string Author
        {
            get;
            
        }

        public MediaFile(string name, double size, string url, string author)
        {
            Name = name;
            Size = size;
            Url = url;
            Author = author;
        }
    }
}
