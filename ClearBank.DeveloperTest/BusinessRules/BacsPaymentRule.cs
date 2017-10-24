using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class BacsPaymentRule:BasePaymentRule, IPaymentRule
    {

        public bool IsPaymentAllowed(Account account, decimal amount)
        {
            if (this.IsAccountSuitable(account,AllowedPaymentSchemes.Bacs))
            {
                return  true;
            }
            
            return false;
        }
    }
}
