namespace lab4_3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // Класс Car, представляющий автомобиль
    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string name, int productionYear, int maxSpeed)
        {
            Name = name;
            ProductionYear = productionYear;
            MaxSpeed = maxSpeed;
        }

        //переопределение метода ToString для удобного вывода информации об автомобиле
        public override string ToString()
        {
            return $"{Name}, {ProductionYear}, {MaxSpeed} км/ч";
        }
    }

    //CarCatalog, содержащий массив элементов типа Car
    public class CarCatalog : IEnumerable<Car>
    {
        private readonly Car[] _cars;

        public CarCatalog(Car[] cars)
        {
            _cars = cars;
        }

        //итератор для прямого прохода
        public IEnumerator<Car> GetEnumerator() //IEnumerator определяет функционал для перебора внутренних объектов в контейнере. 
        {
            foreach (var car in _cars)
            {
                yield return car;
            }
        }

        //итератор для обратного прохода
        public IEnumerable<Car> Reverse()
        {
            for (int i = _cars.Length - 1; i >= 0; i--)
            {
                yield return _cars[i];
            }
        }

        //итератор с фильтром по году выпуска
        public IEnumerable<Car> FilterByProductionYear(int year)
        {
            foreach (var car in _cars)
            {
                if (car.ProductionYear == year)
                {
                    yield return car;
                }
            }
        }

        //итератор с фильтром по максимальной скорости
        public IEnumerable<Car> FilterByMaxSpeed(int maxSpeed)
        {
            foreach (var car in _cars)
            {
                if (car.MaxSpeed >= maxSpeed)
                {
                    yield return car;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание массива автомобилей
            Car[] cars =
            [
            new Car("Toyota", 2015, 180),
            new Car("Ford", 2010, 200),
            new Car("BMW", 2017, 240),
            new Car("Hyundai", 2020, 220),
            new Car("Audi", 2017, 260),
            new Car("Tesla", 2107, 580)
            ];

            // Создание экземпляра CarCatalog
            CarCatalog carCatalog = new CarCatalog(cars);

            // Прямой проход
            Console.WriteLine("Прямой проход:");
            foreach (var car in carCatalog)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            // Обратный проход
            Console.WriteLine("Обратный проход:");
            foreach (var car in carCatalog.Reverse())
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            // Проход по элементам массива с фильтром по году выпуска
            int filterYear = 2017;
            Console.WriteLine($"Автомобили, выпущенные в {filterYear} году:");
            foreach (var car in carCatalog.FilterByProductionYear(filterYear))
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            // Проход по элементам массива с фильтром по максимальной скорости
            int minSpeed = 240;
            Console.WriteLine($"Автомобили с максимальной скоростью не менее {minSpeed} км/ч:");
            foreach (var car in carCatalog.FilterByMaxSpeed(minSpeed))
            {
                Console.WriteLine(car);
            }
        }
    }
}
