using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class ChapsPaymentRule : BasePaymentRule, IPaymentRule
    {
        
            public bool IsPaymentAllowed(Account account, decimal amount)
            {
                if (this.IsAccountSuitable(account,AllowedPaymentSchemes.Chaps)
                    && account.Status == AccountStatus.Live)
                {
                    return true;
                }

                return false;
            }
        }

}
