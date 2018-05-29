using CoreApplicationIO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class DataGenerator
    {
        public List<Car> GetData()
        {
            var result = new List<Car>();
            Random rand = new Random();
            for (int i = 0; i < Configurations.NumberOfInstances; i++)
            {
                // Gets random Model and Version of a car
                NameValueCollection model_version = Helpers.ModelVersion;
                int r = rand.Next(model_version.Count);
                var model = model_version.Keys.Get(r);
                var versions = model_version.GetValues(model);
                var version = versions.GetValue(rand.Next(versions.Length));

                //Gets random date between 2015 and 2020 years
                TimeSpan timeSpan = new DateTime(2020, 12, 31) - new DateTime(2015, 1, 1);
                TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
                DateTime newDate = new DateTime(2015, 1, 1) + newSpan;

                var car = new Car()
                {
                    CarId = Guid.NewGuid(),
                    Model = (CarModel)Enum.Parse(typeof(CarModel), model),
                    ModelVersion = version.ToString(),
                    Engine = Helpers.Engine[rand.Next(Helpers.Engine.Count())],
                    Displacement = Helpers.Displacement[rand.Next(Helpers.Displacement.Count())],
                    Speed = rand.Next(17, 32) * 10.0,
                    Date = newDate
                };

                result.Add(car);
            }

            return result;
        }
    }
}
