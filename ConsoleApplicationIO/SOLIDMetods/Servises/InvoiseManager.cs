using SOLIDMetods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLIDMetods.Servises
{
    public class InvoiseManager
    {
        Importer importer;
        Sender sender;

        public List <Invoise> SearchInvoice(Invoise invoise)  {
            return new List<Invoise>();  }

        public bool AddInvoice(Invoise invoise) {
            return true;
        }
        public bool DeleteInvoice(Invoise invoise) {
            return true;
        }
        public bool UpdateInvoice(Invoise invoise) {
            return true;
        }
        public bool ValidateInvoice(Invoise invoise)
        {
            return true;
        }
       
    }
}
