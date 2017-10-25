using System;
using ClearBank.DeveloperTest.BusinessRules;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClearBank.DeveloperTest.Tests
{
    [TestClass]
    public class PaymentServiceTests
    {
        private Mock<IAccountDataStoreFactory> _dataStoreFactory;
        private Mock<IPaymentRuleFactory> _paymentRuleFactory;
        private Mock<IAccountDataStore> _accountDataStore;
        private Account _testAccount;
        private Mock<IPaymentRule> _testPaymentRule;


        [TestInitialize]
        public void Initialize()
        {
            _testAccount = new Account() { };
            _dataStoreFactory = new Mock<IAccountDataStoreFactory>();
            _paymentRuleFactory = new Mock<IPaymentRuleFactory>();
            _accountDataStore = new Mock<IAccountDataStore>();
            _accountDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(_testAccount);
            _dataStoreFactory
                .Setup(x => x.Create(String.Empty))
                .Returns(_accountDataStore.Object);
            _testPaymentRule = new Mock<IPaymentRule>();
            _paymentRuleFactory.Setup(x => x.Create(It.IsAny<PaymentScheme>())).Returns(_testPaymentRule.Object);
           
            
        }



        [TestMethod]
        public void MakePayment_WhenPaymentRuleNotAllowed_ReturnsSuccessIsFalse()
        {
            _testPaymentRule.Setup(x => x.IsPaymentAllowed(It.IsAny<Account>(), It.IsAny<Decimal>())).Returns(false);
            var paymentService = new PaymentService(_paymentRuleFactory.Object, _dataStoreFactory.Object);
            MakePaymentRequest testPaymentRequest = new MakePaymentRequest() {DebtorAccountNumber = "76543210"};
            var result = paymentService.MakePayment(testPaymentRequest);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void MakePayment_WhenPaymentRuleAllowed_ReturnsSuccessIsFalse()
        {
            _testPaymentRule.Setup(x => x.IsPaymentAllowed(It.IsAny<Account>(), It.IsAny<Decimal>())).Returns(true);
            var paymentService = new PaymentService(_paymentRuleFactory.Object, _dataStoreFactory.Object);
            MakePaymentRequest testPaymentRequest = new MakePaymentRequest() { DebtorAccountNumber = "76543210" };
            var result = paymentService.MakePayment(testPaymentRequest);
            Assert.IsTrue(result.Success);
        }
        //add further tests for balance checking etc


    }
}
