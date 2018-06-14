using SOLIDMetods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLIDMetods.PaymentMethods
{
  public interface Payment
    {
        bool Pay(Invoise invoice);
    }
}
