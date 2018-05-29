using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApplicationIO.Models
{
    public class SearchFilter
    {
        public string Model { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
