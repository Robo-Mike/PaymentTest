using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System.Configuration;
using ClearBank.DeveloperTest.BusinessRules;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var result = new MakePaymentResult();
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];
            var accountDataStore = new AccountDataStore(dataStoreType);
            var account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            if (account == null)
            {
                return result;
            }

            IPaymentRule paymentRule = null;
            paymentRule = new PaymentRuleFactory().Create(request.PaymentScheme);

            if (paymentRule.IsPaymentAllowed(account, request.Amount))
            {
                account.Balance -= request.Amount;
                accountDataStore.UpdateAccount(account);
                //Have incorporated this so account check and update can be atomic
                accountDataStore.Commit();
                result.Success = true;
            }

            return result;
        }
    }
}
