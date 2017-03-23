using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Common
{
    public class Person
    {
        public Gender Gender;
        public DateTime BirthDate { get; set; }
        public int GetFullYears(DateTime now)
        {
            return (now >= BirthDate) ? now.Year - BirthDate.Year : 0;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        public Person(){}
        public Person(string firstName, string lastName, Gender gender, DateTime birthDate): this()
            {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
        }
    }
}
