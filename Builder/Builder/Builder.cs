using System;

namespace Builder
{
    public static class Builder
    {
        public static void Run()
        {
            var director = new VehicleDirector();

            var carBuilder = new CarBuilder();
            var car = director.Construct(carBuilder);
            Console.WriteLine(car);

            var bikeBuilder = new BikeBuilder();
            var bike = director.Construct(bikeBuilder);
            Console.WriteLine(bike);
        }

        public class Vehicle
        {
            public string? Type { get; set; }
            public string? Engine { get; set; }
            public int Wheels { get; set; }

            public override string ToString()
            {
                return $"[Vehicle] Type: {Type}, Engine: {Engine}, Wheels: {Wheels}";
            }
        }

        public interface IVehicleBuilder
        {
            void SetType();
            void SetEngine();
            void SetWheels();
            Vehicle GetResult();
        }

        public class CarBuilder : IVehicleBuilder
        {
            private readonly Vehicle _vehicle = new();

            public void SetType() => _vehicle.Type = "Car";
            public void SetEngine() => _vehicle.Engine = "V6";
            public void SetWheels() => _vehicle.Wheels = 4;
            public Vehicle GetResult() => _vehicle;
        }

        public class BikeBuilder : IVehicleBuilder
        {
            private readonly Vehicle _vehicle = new();

            public void SetType() => _vehicle.Type = "Bike";
            public void SetEngine() => _vehicle.Engine = "Single-cylinder";
            public void SetWheels() => _vehicle.Wheels = 2;
            public Vehicle GetResult() => _vehicle;
        }

        public class VehicleDirector
        {
            public Vehicle Construct(IVehicleBuilder builder)
            {
                builder.SetType();
                builder.SetEngine();
                builder.SetWheels();
                return builder.GetResult();
            }
        }
    }
}
