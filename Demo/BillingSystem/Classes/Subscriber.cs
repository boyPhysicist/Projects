using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Interfaces;

namespace BillingSystem.Classes
{
    public class Subscriber : ISubscriber
    {
        public string Name { get; }

        public int Age { get; }

        public int Id { get; }

        public Subscriber(string name, int age, int id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        
    }
    
}
