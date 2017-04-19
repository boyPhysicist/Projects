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

        public double FuelTankCapacity
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

        public double FlightRange
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

        public string Engines
        {
            get;
        }

        public int NumEngines
        {
            get;
        }

        public double FuelConsumption
        {
            get;
        }

        public CargoPlane(double height, double lenght, double wingArea, double wingSpan, string name, string model, 
            double emptyWeight, double fuelTankCapacity, double maxLandingWeight, double maxTakeOffWeight,
            double flightRange, double maxSpeed, double maxHeight, double runningLenght, double meanFreePath,
            string engines, int numEngines, double fuelConsumption)
            : base(height, lenght, wingArea, wingSpan, name, model)
        {
            EmptyWeight = emptyWeight;
            FuelTankCapacity = fuelTankCapacity;
            MaxLandingWeight = maxLandingWeight;
            MaxTakeOffWeight = maxTakeOffWeight;
            FlightRange = flightRange;
            MaxSpeed = maxSpeed;
            MaxHeight = maxHeight;
            RunningLenght = runningLenght;
            MeanFreePath = meanFreePath;
            Engines = engines;
            NumEngines = numEngines;
            FuelConsumption = fuelConsumption;

        }

        
    }
}
