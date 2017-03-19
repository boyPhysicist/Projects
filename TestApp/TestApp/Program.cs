using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double q = 0;
            while (q != 10)
            {
                Console.WriteLine("Hello world");
                if (q == 3)
                    {
                    Console.WriteLine("Hello BLR!!!");
                        }
                q+=1;
                
            }

            var s = "*";
            var w="";
            
            for (int i = 0; i<=50; i++)
            {
                w = w + s;
                
                Console.WriteLine(w);
            }

            int x = 0;
            do
            {
                Console.WriteLine(x);
                x++;
            } while (x <= 5);


            int[] fibarray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
            foreach (int element in fibarray)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            for (int i = 0; i < fibarray.Length; i++)
            {
                Console.WriteLine(fibarray[i]);
            }
            Console.WriteLine();

            int count = 0;
            foreach (int element in fibarray)
            {
                count += 1;
                Console.WriteLine("Element #{0}: {1}", count, element);
            }
            Console.WriteLine("Количество чисел: {0}", count);
            Console.ReadKey();
        }
          
            
        
        }
    }

