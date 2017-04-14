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
            
          
            
        }

        public string Name
        {
            get;
        }

        public Compilation(ICollection<IMediaFileItems> items, string name)
        {

            Name = name;
            if (items is PictureFile || items is VideoFile)
            {
                Items = items;
            }
        }


        public void Change(int indexA, int indexB)
        {
            

        }

    }
}
