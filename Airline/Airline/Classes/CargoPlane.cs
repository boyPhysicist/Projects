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
            else { Console.WriteLine("Please enter a valid value for Height"); }

            if (lenght >= 0)
             { Length = lenght; }
            else { Console.WriteLine("Please enter a valid value for Length"); }

            if (wingArea >= 0)
            { WingArea = wingArea; }
            else { Console.WriteLine("Please enter a valid value for WingArea"); }

            if (wingSpan >= 0)
            { WingSpan = wingSpan; }
            else { Console.WriteLine("Please enter a valid value for WingSpan"); }

            if (emptyWeight >= 0)
            { EmptyWeight = emptyWeight; }
            else { Console.WriteLine("Please enter a valid value for EmptyWeight"); }

            if (fuelTankCapacity >= 0)
            { FuelTankCapacity = fuelTankCapacity; }
            else { Console.WriteLine("Please enter a valid value for FuelTankCapacity"); }

            if (maxTakeOffWeight >= 0)
            { MaxTakeOffWeight = maxTakeOffWeight; }
            else { Console.WriteLine("Please enter a valid value for MaxTakeOffWeight"); }

            if (maxLandingWeight >= 0)
            { MaxLandingWeight = maxLandingWeight; }
            else { Console.WriteLine("Please enter a valid value for MaxLandingWeight"); }

            if (flightRange >= 0)
            { FlightRange = flightRange; }
            else { Console.WriteLine("Please enter a valid value for FlightRange"); }

            if (fuelConsumptionLiterPerHour >= 0)
            { FuelConsumptionLiterPerHour = fuelConsumptionLiterPerHour; }
            else { Console.WriteLine("Please enter a valid value for FuelConsumptionLiterPerHour"); }

            if (maxSpeed >= 0)
            { MaxSpeed = maxSpeed; }
            else { Console.WriteLine("Please enter a valid value for MaxSpeed"); }


            if (maxHeight >= 0)
            { MaxHeight = maxHeight; }
            else { Console.WriteLine("Please enter a valid value for MaxHeight"); }

            if (runningLenght >= 0)
            { RunningLenght = runningLenght; }
            else { Console.WriteLine("Please enter a valid value for RunningLenght"); }

            if (meanFreePath >= 0)
            { MeanFreePath = meanFreePath; }
            else { Console.WriteLine("Please enter a valid value for MeanFreePath"); }

            EnginesName = enginesName;

            if (numEngines >= 0)
            { NumEngines = numEngines; }
            else { Console.WriteLine("Please enter a valid value for NumEngines"); }


        }


    }


    


}

