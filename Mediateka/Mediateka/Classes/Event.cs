using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Mediateka.Classes
{
    class Event : ICollection<IMediaFileItems>
    {
        private ICollection<IMediaFileItems> FileItem = new List<IMediaFileItems>();

        public int Count
        {
            get
            {
                return FileItem.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return FileItem.IsReadOnly;
            }
        }

        public void Add(IMediaFileItems item)
        {
            if (item is PictureFile || item is VideoFile)
            { FileItem.Add(item); }
            else { Console.WriteLine("Вы пытаетесь добавить неверный элемент. Тип элемента {0}", item); }
        }

        public void Clear()
        {
            FileItem.Clear();
        }

        public bool Contains(IMediaFileItems item)
        {
            return FileItem.Contains(item);
        }

        public void CopyTo(IMediaFileItems[] array, int arrayIndex)
        {
            FileItem.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IMediaFileItems> GetEnumerator()
        {
            return FileItem.GetEnumerator();
        }

        public bool Remove(IMediaFileItems item)
        {
            return FileItem.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return FileItem.GetEnumerator();
        }

       
        //public ICollection<IMediaFileItems> Items
        //{
        //    get;

        //}

        //public string Name
        //{
        //    get;

        //}

        //public Event(ICollection<IMediaFileItems> items, string name)
        //{

        //    Items = items;
        //    Name = name;

        //}
    }
}
