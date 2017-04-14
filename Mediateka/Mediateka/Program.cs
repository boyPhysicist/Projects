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
            
            PictureFile p = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg");
            PictureFile p1 = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg");
            PictureFile p2 = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg");
            PictureFile p3 = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg");
            AudioFile b = new AudioFile("audio", 123, "jsjs", "phill", 256, "mp3", 120);
            VideoFile v = new VideoFile("video", 124, "jdjfjf", "asd", 212, a, "avi", 123);

            ICollection<MediaFile> k = new List<MediaFile>();
            CreatorAssembles z = new CreatorAssembles();
            var i = z.CreateDisk(k, p);
            i = z.CreateDisk(k, b);
            i = z.CreateDisk(k, v);
            Console.WriteLine(i.Count);
            
            Console.WriteLine();
            Console.ReadKey();
           
        

        }
    }
}
