using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class ChapsPaymentRule: IPaymentRule
    {
        private readonly IAccountSuitableRule _accountSuitableRule;

        public ChapsPaymentRule(IAccountSuitableRule accountSuitableRule)
        {
            _accountSuitableRule = accountSuitableRule;
        }

        public bool IsPaymentAllowed(Account account, decimal amount)
            {
                if (_accountSuitableRule.IsAccountSuitable(account,AllowedPaymentSchemes.Chaps)
                    && account.Status == AccountStatus.Live)
                {
                    return true;
                }

                return false;
            }
        }

}
