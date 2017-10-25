using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class AccountSuitableRule : IAccountSuitableRule
    {
        public  bool IsAccountSuitable(Account account, AllowedPaymentSchemes scheme)
        {
            if (account.AllowedPaymentSchemes.HasFlag(scheme))
            {
                return true;
            }

            return false;
        }
    }
}
