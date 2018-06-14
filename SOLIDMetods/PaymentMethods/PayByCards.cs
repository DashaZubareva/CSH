using SOLIDMetods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLIDMetods.PaymentMethods
{
   public  interface IPayByCards
    {
        Card card { set; get; }

        bool PayBycard (Invoise invoise) ;
    }
}
