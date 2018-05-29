using CoreApplicationIO;
using CoreApplicationIO.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationIO
{
	class Program
	{
		static void Main(string[] args)
		{
			var carManager = new CarManager(@"D:\Anton\DATA\DATA.csv");
			Car car = null;

			foreach (var carItem in carManager.GetCars("", "2020", "Benzine"))
			{
				Console.WriteLine(carItem.DisplayString());
			}
			Console.WriteLine("------");
			Console.ReadKey();

            Console.WriteLine("GetCars using search filter");
            var searchFilter = new CoreApplicationIO.Models.SearchFilter
            {
                Model = string.Empty,
                Year = "2019",
                Engine = "Benzine",
                DateFrom = new DateTime(2015, 10, 10),
            };
            foreach (var carItem in carManager.GetCars(searchFilter))
            {
                Console.WriteLine(carItem.DisplayString());
            }
            Console.WriteLine("------");
            Console.ReadKey();


            /*
			car = new Car
			{
				Model = CarModel.Toyota,
				ModelVersion = "Land Couser Prada",
				Engine = "Benzine",
				Displacement = 3000,
				Speed = 200.0,
				Date = new DateTime(2010, 10, 20)
			};

			carManager.AddCar(car);
			foreach (var carItem in carManager.GetCars())
			{
				Console.WriteLine(carItem.DisplayString());
			}
			Console.WriteLine("-----------");
			Console.ReadKey();

			carManager.RemoveCar(car);
			foreach (var carItem in carManager.GetCars())
			{
				Console.WriteLine(carItem.DisplayString());
			}
			Console.WriteLine("-----------");
			Console.ReadKey();

			car = carManager.Cars[0];
			car.Model = CarModel.Nissan;
			carManager.UpdateCar(car);
			foreach (var carItem in carManager.GetCars())
			{
				Console.WriteLine(carItem.DisplayString());
			}
			Console.WriteLine("-----------");
			Console.ReadKey();

    */
        }
	}
}
