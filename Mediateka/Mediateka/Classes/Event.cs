using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Mediateka.Classes
{
    class Event : IBuffer
    {



        public ICollection<IMediaFileItems> Items
        {
            get;

        }

        public string Name
        {
            get;

        }

        public Event(ICollection<IMediaFileItems> items, string name)
        {
            if (items is PictureFile || items is VideoFile)
            { Items = items;  }
            else { Console.WriteLine("Вы пытаетесь добавить неверный элемент. Тип элемента {0}", items); }
            
            Name = name;

        }
    }
}
