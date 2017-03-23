using App1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            Person p1 = new Person("John", "Silver", Gender.Male, new DateTime(1972,1,1));
            Person p2 = new Person()
            {
                FirstName = "John",
                LastName = "Silver",
                BirthDate = new DateTime(1672, 1, 1),
                Gender = Gender.Male
            };
            Console.WriteLine("{0} Age = {1}", p2.FullName, p2.GetFullYears(DateTime.Now));
            Console.Read();
        }
    }
}
