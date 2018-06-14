using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLIDMetods.Models
{
   public class Invoise
    {
        public int InvoiceId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ClientInfo { get; set; }
        public string BillInfo { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }



    }
}
