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
            PictureFile p = new PictureFile("picture", 123, "jsjsjs", "phill", a, "jpeg", "audio");
            AudioFile b = new AudioFile("audio", 123, "jsjs", "phill", 256, "mp3", 120);
            Event e = new Event(new List<IPicture>(), "Main");
            e.Items.Add(p);
            e.Items.Add(b);

        }
    }
}
