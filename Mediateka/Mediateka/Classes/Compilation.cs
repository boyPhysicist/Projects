using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    class Compilation : IBuffer
    {
        public ICollection<IMediaFileItems> Items
        {
            get;
            
            set;
            
        }

        public string Name
        {
            get; set;
            
        }
    }
}
