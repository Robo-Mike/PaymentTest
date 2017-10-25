using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public interface IAccountSuitableRule
    {
        bool IsAccountSuitable(Account account, AllowedPaymentSchemes scheme);
    }
}