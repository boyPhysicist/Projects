using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Common
{
    public class Employee:Person
    {
        public string WorkPlaceInfo { get; set; }

        public Employee() { }
        public Employee(string firstName, string lastName, Gender gender, DateTime birthDate, string workPlaceInfo ):base(firstName: firstName, lastName:lastName,gender:gender, birthDate: birthDate)
        {
            WorkPlaceInfo = workPlaceInfo;
        }
    }
}
