using Airline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Classes
{
    public class PassengerPlane : CargoPlane, IPassenger
    {
        
        public int NumSeats
        {
            get;
            
        }

        public SalonClasses SalonClass
        {
            get;
        }


        public PassengerPlane(double height, double lenght, double wingArea, double wingSpan, string name, 
            string model, double emptyWeight, double fuelTankCapacity, double maxLandingWeight, double maxTakeOffWeight, 
            double flightRange, double maxSpeed, double maxHeight, double runningLenght, double meanFreePath, 
            string engines, int numEngines, double fuelConsumption, int numSeats, SalonClasses salonClass) 
            : base(height, lenght, wingArea, wingSpan, name, model, emptyWeight, 
                  fuelTankCapacity, maxLandingWeight, maxTakeOffWeight, flightRange, maxSpeed, 
                  maxHeight, runningLenght, meanFreePath, engines, numEngines, fuelConsumption)
        {
            SalonClass = salonClass;
            NumSeats = numSeats;
        }


    }
}
