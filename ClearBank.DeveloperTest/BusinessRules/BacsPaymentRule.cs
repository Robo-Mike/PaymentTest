using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class BacsPaymentRule:IPaymentRule
    {
        private readonly IAccountSuitableRule _accountSuitableRule;

        public BacsPaymentRule(IAccountSuitableRule accountSuitableRule)
        {
            _accountSuitableRule = accountSuitableRule;
        }
        public bool IsPaymentAllowed(Account account, decimal amount)
        {
            if (_accountSuitableRule.IsAccountSuitable(account,AllowedPaymentSchemes.Bacs))
            {
                return  true;
            }
            
            return false;
        }
    }
}
