using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public interface IPaymentRule
    {
        bool IsPaymentAllowed(Account account, decimal amount);
    }
}