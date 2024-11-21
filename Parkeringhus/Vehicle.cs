using System;    //Vehicle.cs
namespace Parkeringhus
{
    public abstract class Vehicle
    {
        public string LicensePlate { get; set; }
        public int ParkingSpotNumber { get; set; }
        public string Color { get; set; }

        public Vehicle(string licensePlate, string color)
        {
            LicensePlate = licensePlate;
            Color = color;
        }

        public abstract void DisplayInfo();
    }

    public class Car : Vehicle
    {
        public Car(string licensePlate, string color) : base(licensePlate, color) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Bil: {LicensePlate}, Färg: {Color}, Parkeringsplats: {ParkingSpotNumber}");
        }
    }

    public class Motorcycle : Vehicle
    {
        public Motorcycle(string licensePlate, string color) : base(licensePlate, color) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"MC: {LicensePlate}, Färg: {Color}, Parkeringsplats: {ParkingSpotNumber}");
        }
    }

    public class Bus : Vehicle
    {
        public Bus(string licensePlate, string color) : base(licensePlate, color) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Buss: {LicensePlate}, Färg: {Color}, Parkeringsplats: {ParkingSpotNumber}");
        }
    }
}
