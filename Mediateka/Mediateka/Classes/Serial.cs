using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    class Serial : IBuffer
    {
        public ICollection<IMediaFileItems> Items
        {
            get;
        }

        public ICollection<IMediaFileItems> VItems
        {
            get;
        }

        public string Name
        {
            get;
            
        }

        public Serial(string name, ICollection<IMediaFileItems> items, ICollection<IMediaFileItems> vItems)
        {
            Name = name;
            if(items is PictureFile)
            {
                Items = items;
            }
            else
            {
                Console.WriteLine("Элемент должен быть типа PictureFile");

            }

            if(vItems is VideoFile)
            {
                VItems = vItems;
            }
            else
            {
                Console.WriteLine("Элемент должен быть типа VideoFile");
            }

        }
    }
}
