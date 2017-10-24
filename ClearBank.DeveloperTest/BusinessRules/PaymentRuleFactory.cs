using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class PaymentRuleFactory
    {
        public IPaymentRule Create(PaymentScheme scheme)
        {
            switch (scheme)
            {
                case PaymentScheme.Bacs:
                    return new BacsPaymentRule();
                case PaymentScheme.FasterPayments:
                    return new FasterPaymentsPaymentRule();
                case PaymentScheme.Chaps:
                    return new ChapsPaymentRule();
                default:
                    throw new InvalidEnumArgumentException("Payment scheme not recognised");
            }
        }
    }
}
