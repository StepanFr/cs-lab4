namespace lab4_2
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }

        // Конструктор класса Car
        public Car(string name, int productionYear, int maxSpeed)
        {
            Name = name;
            ProductionYear = productionYear;
            MaxSpeed = maxSpeed;
        }

        // Переопределение метода ToString для удобного вывода информации об автомобиле
        public override string ToString()
        {
            return $"{Name}, {ProductionYear}, {MaxSpeed} км/ч";
        }
    }

    // Класс CarComparer, реализующий интерфейс IComparer<Car>
    public class CarComparer : IComparer<Car>
    {
        public enum SortBy
        {
            Name,
            ProductionYear,
            MaxSpeed
        }

        private SortBy _sortBy;

        // Конструктор для установки критерия сортировки
        public CarComparer(SortBy sortBy)
        {
            _sortBy = sortBy;
        }

        // Метод сравнения
        public int Compare(Car x, Car y)
        {
            switch (_sortBy)
            {
                case SortBy.Name:
                    return string.Compare(x.Name, y.Name);
                case SortBy.ProductionYear:
                    return x.ProductionYear.CompareTo(y.ProductionYear);
                case SortBy.MaxSpeed:
                    return x.MaxSpeed.CompareTo(y.MaxSpeed);
                default:
                    throw new ArgumentException("Неизвестный критерий сортировки");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание массива автомобилей
            Car[] cars = new Car[]
            {
            new Car("Toyota", 2015, 180),
            new Car("Ford", 2010, 200),
            new Car("BMW", 2018, 240),
            new Car("Hyundai", 2020, 220),
            new Car("Audi", 2017, 260),
            new Car("Tesla", 2107, 580)
            };

            // Сортировка по названию
            Array.Sort(cars, new CarComparer(CarComparer.SortBy.Name));
            Console.WriteLine("Сортирoвка по названию:");
            foreach (var car in cars) //foreach
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            // Сортировка по году выпуска
            Array.Sort(cars, new CarComparer(CarComparer.SortBy.ProductionYear));
            Console.WriteLine("Сортировка по году выпуска:");
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            // Сортировка по максимальной скорости
            Array.Sort(cars, new CarComparer(CarComparer.SortBy.MaxSpeed));
            Console.WriteLine("Сортировка по максимальной скорости:");
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
