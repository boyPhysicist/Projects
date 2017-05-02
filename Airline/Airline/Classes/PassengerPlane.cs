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
        public override string GetTypeOfPlane()
        {
           return("This is passenger plane.");
        }

        public override int GetPassengerСapacity()
        {
             return NumSeats;
        }
        public override double GetCarryingCapacity()
        {
            return MaxTakeOffWeight - EmptyWeight;
        }

        public PassengerPlane(string name, string model, double height, double lenght, double wingArea, double wingSpan,
            double emptyWeight, double fuelTankCapacity, double maxTakeOffWeight, double maxLandingWeight, 
            double flightRange, double fuelConsumptionLiterPerHour, double maxSpeed, double maxHeight, 
            double runningLenght, double meanFreePath, string enginesName, int numEngines, int numSeats, SalonClasses salonClass) 
            : base(name, model, height, lenght, wingArea, wingSpan, emptyWeight, fuelTankCapacity, maxTakeOffWeight, 
                  maxLandingWeight, flightRange, fuelConsumptionLiterPerHour, maxSpeed, maxHeight, runningLenght, 
                  meanFreePath, enginesName, numEngines)
        {
            if (numSeats >= 0)
            {
                NumSeats = numSeats;
            }
            else
            {
                NumSeats = 0;
            }

            SalonClass = salonClass;

        }

        

        


       

    }
}
