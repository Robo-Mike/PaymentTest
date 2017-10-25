using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class FasterPaymentsPaymentRule:IPaymentRule
    {
        private readonly IAccountSuitableRule _accountSuitableRule;

        public FasterPaymentsPaymentRule(IAccountSuitableRule accountSuitableRule)
        {
            _accountSuitableRule = accountSuitableRule;
        }
        public bool IsPaymentAllowed(Account account, decimal amount)
        {
            if (_accountSuitableRule.IsAccountSuitable(account,AllowedPaymentSchemes.FasterPayments) 
                && account.Balance >= amount)
            {
                return true;
            }

            return false;
        }
    }
}
