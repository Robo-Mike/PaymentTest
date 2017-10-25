using System.ComponentModel;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public interface IPaymentRuleFactory
    {
        IPaymentRule Create(PaymentScheme scheme);
    }

    public class PaymentRuleFactory : IPaymentRuleFactory
    {
        private readonly IAccountSuitableRule _accountSuitableRule;

        public PaymentRuleFactory(IAccountSuitableRule accountSuitableRule)
        {
            _accountSuitableRule = accountSuitableRule;
        }
        public IPaymentRule Create(PaymentScheme scheme)
        {
            switch (scheme)
            {
                case PaymentScheme.Bacs:
                    return new BacsPaymentRule(_accountSuitableRule);
                case PaymentScheme.FasterPayments:
                    return new FasterPaymentsPaymentRule(_accountSuitableRule);
                case PaymentScheme.Chaps:
                    return new ChapsPaymentRule(_accountSuitableRule);
                default:
                    throw new InvalidEnumArgumentException("Payment scheme not recognised");
            }
        }
    }
}
