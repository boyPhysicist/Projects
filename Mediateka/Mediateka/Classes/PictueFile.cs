using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    public class PictueFile : MediaFile, IResolution, IType
    {
        public int[] Resolution
        {
            get;
            
        }

        public string Type
        {
            get;
            
        }



        public PictueFile(string name, double size, string url, string author, int[] resolution, string type) : base(name, size, url, author)
        {
            Resolution = resolution;
            Type = type;
        }

       
    }
}
