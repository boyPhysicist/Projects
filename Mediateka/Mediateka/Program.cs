using Mediateka.Classes;
using Mediateka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[2];
            a[0] = 1024;
            a[1] = 768;
            ICollection<IMediaFileItems> k = new List<IMediaFileItems>;
            PictureFile p = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg");
            PictureFile p1 = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg");
            PictureFile p2 = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg");
            PictureFile p3 = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg");
            AudioFile b = new AudioFile("audio", 123, "jsjs", "phill", 256, "mp3", 120);
            k.Add(p);
            Event e = new Event(k,"kkkkk");


            
            Console.WriteLine();
            Console.ReadKey();
           
        

        }
    }
}
