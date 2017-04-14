using Mediateka.Interfaces;
using Mediateka.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    class Disk : IBuffer
    {
        public ICollection<IMediaFileItems> Items
        {
            get;

        }

        public string Name
        {
            get;
        }

        public Disk(string name, ICollection<IMediaFileItems> items)
        {
            Name = name;
            if (items is PictureFile || items is VideoFile)
            {
                Items = items;
            }
            
        }

    }
    
}



