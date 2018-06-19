using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOLIDMetods.Models;

namespace SOLIDMetods.PaymentMethods
{
    public class PaymentManager: IPayByCards
    {
        public Card card { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CancelPay() {
            return true; }

        public bool PayBycard(Invoise invoise)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePay()
        {
            return true;
        }

    }
}
