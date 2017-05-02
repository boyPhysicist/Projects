using Airline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Classes
{
    public class CargoPlane : AirplaneModel,ICargo,IFlyable
    {
        public double EmptyWeight
        {
            get;
        }

        public override double FlightRange
        {
            get;
        }

        public override double FuelConsumptionLiterPerHour
        {
            get;
        }

        public double FuelTankCapacity
        {
            get;
        }

        public override double Height
        {
            get;
        }

        public override double Length
        {
            get;
        }

        public double MaxLandingWeight
        {
            get;
        }

        public double MaxTakeOffWeight
        {
            get;
        }

        public override string Model
        {
            get;
        }

        public override string Name
        {
            get;
        }

        public override double WingArea
        {
            get;
        }

        public override double WingSpan
        {
            get;
        }

        public double MaxSpeed
        {
            get;
        }

        public double MaxHeight
        {
            get;
        }

        public double RunningLenght
        {
            get;
        }

        public double MeanFreePath
        {
            get;
        }

        public string EnginesName
        {
            get;
        }

        public int NumEngines
        {
            get;
        }

        public override int GetPassengerСapacity()
        {
           return 0;
        }

        public override string GetTypeOfPlane()
        {
            return("This is cargo plane.");
        }

        public override double GetCarryingCapacity()
        {
            return MaxTakeOffWeight-EmptyWeight;
        }

        public override string GetPlane()
        {
            return Name+""+Model;
        }

        public CargoPlane(string name, string model, double height, double lenght, double wingArea, double wingSpan,
                            double emptyWeight, double fuelTankCapacity, double maxTakeOffWeight, 
                            double maxLandingWeight, double flightRange, double fuelConsumptionLiterPerHour, 
                            double maxSpeed, double maxHeight, double runningLenght, double meanFreePath, string enginesName, 
                             int numEngines )
        {
            Name = name;
            Model = model;

            if(height >= 0)
             { Height = height; }
            else { throw new Exception("Incorrect value"); }
            if (lenght >= 0)
             { Length = lenght; }
            else { throw new Exception("Incorrect value"); }
            if (wingArea >= 0)
            { WingArea = wingArea; }
            else { throw new Exception("Incorrect value"); }

            if (wingSpan >= 0)
            { WingSpan = wingSpan; }
            else { throw new Exception("Incorrect value"); }
            if (emptyWeight >= 0)
            { EmptyWeight = emptyWeight; }
            else { throw new Exception("Incorrect value"); }

            if (fuelTankCapacity >= 0)
            { FuelTankCapacity = fuelTankCapacity; }
            else { throw new Exception("Incorrect value"); }
            if (maxTakeOffWeight >= 0)
            { MaxTakeOffWeight = maxTakeOffWeight; }
            else { throw new Exception("Incorrect value"); }
            if (maxLandingWeight >= 0)
            { MaxLandingWeight = maxLandingWeight; }
            else { throw new Exception("Incorrect value"); }
            if (flightRange >= 0)
            { FlightRange = flightRange; }
            else { throw new Exception("Incorrect value"); }
            if (fuelConsumptionLiterPerHour >= 0)
            { FuelConsumptionLiterPerHour = fuelConsumptionLiterPerHour; }
            else { throw new Exception("Incorrect value"); }

            if (maxSpeed >= 0)
            { MaxSpeed = maxSpeed; }
            else { throw new Exception("Incorrect value"); }
            if (maxHeight >= 0)
            { MaxHeight = maxHeight; }
            else { throw new Exception("Incorrect value"); }
            if (runningLenght >= 0)
            { RunningLenght = runningLenght; }
            else { throw new Exception("Incorrect value"); }
            if (meanFreePath >= 0)
            { MeanFreePath = meanFreePath; }
            else { throw new Exception("Incorrect value"); }
            EnginesName = enginesName;

            
            if (numEngines >= 0)
            { NumEngines = numEngines; }
            else { throw new Exception("Incorrect value"); }

        }

        
    }


    


}

