using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.Classes
{
    public class CreatorAssembles
    {
        public  ICollection<MediaFile> CreateDisk(ICollection<MediaFile> w, MediaFile mediaFile)
        {

            MediaFile M = mediaFile;
            ICollection<MediaFile> W = w;
            if (W != null)
            {
                int s = w.Count();
                
            }
            if(M is AudioFile|| M is PictureFile)
            { W.Add(M);
                Console.WriteLine("{0} Добавлен", M.Name);
            }
            else { Console.WriteLine("Error"); };
           
            return w;

            
        }

        public CreatorAssembles() {
           
        }
         
    }
}
