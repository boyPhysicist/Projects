using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler
{
    class Program
    {
        public static void Main(string[] args)
        {
            Parser.Parser parser = new Parser.Parser("text.txt");
            foreach (var item in parser.Start() )
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
