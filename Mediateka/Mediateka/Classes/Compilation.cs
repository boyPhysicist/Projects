using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    class Compilation : Disk
    {
        //public ICollection<IMediaFileItems> Items
        //{
        //    get;

        //    set;

        //}

        //public string Name
        //{
        //    get; set;

        //}
        public Compilation(string name, ICollection<IMediaFileItems> items) : base(name, items)
        {
        }
    }
}
