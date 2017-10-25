using System;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System.Configuration;
using ClearBank.DeveloperTest.BusinessRules;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRuleFactory _paymentRuleFactory;
        private readonly IAccountDataStoreFactory _accountDataStoreFactory;

        //use IOC framework in calling app
        public PaymentService(IPaymentRuleFactory paymentRuleFactory, IAccountDataStoreFactory accountDataStoreFactory)
        {
            _paymentRuleFactory = paymentRuleFactory;
            _accountDataStoreFactory = accountDataStoreFactory;

        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var result = new MakePaymentResult();
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"] ?? String.Empty;
            var accountDataStore = _accountDataStoreFactory.Create(dataStoreType);
            var account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            if (account == null)
            {
                return result;
            }

            var paymentRule = _paymentRuleFactory.Create(request.PaymentScheme);

            if (paymentRule.IsPaymentAllowed(account, request.Amount))
            {
                account.Balance -= request.Amount;
                accountDataStore.UpdateAccount(account);
                //Have incorporated unit of work so account check and update can be atomic
                accountDataStore.Commit();
                result.Success = true;
            }

            return result;
        }
    }
}
