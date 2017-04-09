using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            Items = items;
            Name = name;
            
        }
    }
}
