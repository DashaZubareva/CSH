using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApplicationIO.Interfaces
{
	public interface ICarManager
	{
		StreamReader streamReader { get; set; }
		StreamWriter streamWriter { get; set; }

		List<Car> GetCars();
		Car GetCarByCardId(Guid carId);
		bool AddCar(Car car);
		bool UpdateCar(Car car);
		bool RemoveCar(Guid carId);

		Car ReadFromRow(string row);
	}
}
