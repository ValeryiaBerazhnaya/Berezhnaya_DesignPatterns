using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Observer
{
    public static class ContainerObserver
    {
        public static void Run()
        {
            var container = new Container();

            var bmw = new SportCar("BMW M4", 510);
            var volvo = new Truck("Volvo FH", 18);

            container.AddCar(bmw);
            container.AddCar(volvo);

            bmw.HorsePower = 530;
            volvo.CargoCapacity = 20;
        }

        public abstract class Car : INotifyPropertyChanged
        {
            public string Model { get; protected set; }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName, object oldValue, object newValue)
            {
                PropertyChanged?.Invoke(this, new CarPropertyChangedEventArgs(this.GetType().Name, propertyName, oldValue, newValue));
            }
        }

        public class SportCar : Car
        {
            private int _horsePower;

            public SportCar(string model, int horsePower)
            {
                Model = model;
                HorsePower = horsePower;
            }

            public int HorsePower
            {
                get => _horsePower;
                set
                {
                    if (_horsePower != value)
                    {
                        var old = _horsePower;
                        _horsePower = value;
                        OnPropertyChanged(nameof(HorsePower), old, value);
                    }
                }
            }
        }

        public class Truck : Car
        {
            private int _cargoCapacity;

            public Truck(string model, int cargoCapacity)
            {
                Model = model;
                CargoCapacity = cargoCapacity;
            }

            public int CargoCapacity
            {
                get => _cargoCapacity;
                set
                {
                    if (_cargoCapacity != value)
                    {
                        var old = _cargoCapacity;
                        _cargoCapacity = value;
                        OnPropertyChanged(nameof(CargoCapacity), old, value);
                    }
                }
            }
        }

        public class Container
        {
            private readonly List<Car> _cars = new();

            public void AddCar(Car car)
            {
                _cars.Add(car);
                Console.WriteLine($"[Added] Object: {car.GetType().Name}, Model: {car.Model}");

                car.PropertyChanged += OnCarPropertyChanged;
            }

            private void OnCarPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e is CarPropertyChangedEventArgs args)
                {
                    Console.WriteLine($"[Change] Object: {args.CarType}, Property: {args.PropertyName}, Before: {args.OldValue}, After: {args.NewValue}");
                }
            }
        }

        public class CarPropertyChangedEventArgs : PropertyChangedEventArgs
        {
            public string CarType { get; }
            public object OldValue { get; }
            public object NewValue { get; }

            public CarPropertyChangedEventArgs(string carType, string propertyName, object oldValue, object newValue)
                : base(propertyName)
            {
                CarType = carType;
                OldValue = oldValue;
                NewValue = newValue;
            }
        }
    }
}
