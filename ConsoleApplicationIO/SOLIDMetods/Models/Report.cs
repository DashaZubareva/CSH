using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLIDMetods.Models
{
   public class Report
    {
        List<Invoise> Invoices { get; set; }
        String Header { get; set; }
        String Footer { get; set; }
        DateTime Date { get; set; }

        public Report(List<Invoise> invoices, string header, string footer, DateTime date)
        {
            Invoices = invoices;
            Header = header;
            Footer = footer;
            Date = date;
        }


    }
}
