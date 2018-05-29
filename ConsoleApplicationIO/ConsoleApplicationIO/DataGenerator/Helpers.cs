using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public static class Helpers
    {
        public static readonly NameValueCollection ModelVersion = new NameValueCollection()
        {
            { "Audi", "A4" }, { "Audi", "A8" }, { "Audi", "Q5" }, { "Audi", "Q7" }, { "Audi", "R8" }, { "Audi", "S8" },
            { "BMW", "3 Series" }, { "BMW", "5 Series" }, { "BMW", "X3" }, { "BMW", "X5" }, { "BMW", "X6" },
            { "Mercedes", "C Class" }, { "Mercedes", "E Class" }, { "Mercedes", "S Class" }, { "Mercedes", "GLK Class" },
            { "Nissan", " Pathfinder" }, { "Nissan", " Pick Up" }, { "Nissan", " Quashqai" },{ "Nissan", " X-Trail" },
            { "Toyota", " Highlander" }, { "Toyota", " Land Cruiser" },{ "Toyota", " Land Cruiser Prada" },{ "Toyota", " Rav 4" },
            { "Volkswagen", "Golf Plus" }, { "Volkswagen", "Jetta" }, { "Volkswagen", "Phaeton" },  { "Volkswagen", "Passat CC" },  { "Volkswagen", "Touareg" },
            { "Honda", " CR-V" }, { "Honda", " CR X" }, { "Honda", "  CR-Z" },
            { "Land_Rover", " Defender" },{ "Land_Rover", " Discovery" },{ "Land_Rover", " Freelander" },{ "Land_Rover", " Range_Rover" },
            { "Tesla", " Model S" }, { "Tesla", " Model X" },
            { "Volvo", " S60" }, { "Volvo", " V90" }, { "Volvo", " XC60" }, { "Volvo", " XC70" }, { "Volvo", " XC90" },
            { "Skoda", " Fabia" }, { "Skoda", " Felicia" }, { "Skoda", " Octavia" }, { "Skoda", " Superb" }
        };
        public static readonly string[] Engine = { "Benzine", "Diesel", "Hybrid", "Electra" };
        public static readonly int[] Displacement = { 2000, 2500, 3000, 3600, 4000, 5000 };

        public const int NumberOfInstancies = 1000;

        public const string SeparatorSemicolon = ";";

        public const string DataStorage = "D:\\DATA\\XXX.csv";
    }
}