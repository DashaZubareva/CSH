using SOLIDMetods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLIDMetods.PaymentMethods
{
    public class PayByCArd :Payment
    {
        Card card;

        public Card Card { get => card; set => card = value; }

        public bool Pay(Invoise invoise) => true;
    }
}
