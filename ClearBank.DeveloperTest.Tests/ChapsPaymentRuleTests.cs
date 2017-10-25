using System;
using ClearBank.DeveloperTest.BusinessRules;
using ClearBank.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClearBank.DeveloperTest.Tests
{

        [TestClass]
        public class ChapsPaymentRuleTests
        {

            private ChapsPaymentRule _paymentRule;
            private Decimal testAmount = (decimal) 3.56;
            private Mock<IAccountSuitableRule> _accountSuitableRuleMock;


            [TestInitialize]
            public void Initialize()
            {
                _accountSuitableRuleMock = new Mock<IAccountSuitableRule>();
                _accountSuitableRuleMock
                    .Setup(x => x.IsAccountSuitable(It.IsAny<Account>(), It.IsAny<AllowedPaymentSchemes>()))
                    .Returns(true);
                _paymentRule = new ChapsPaymentRule(_accountSuitableRuleMock.Object);
            }



            [TestMethod]
            public void IsPaymentAllowed_WhenAccountStatusDisabled_ReturnsFalse()
            {
                Account nonLiveChapsAccount = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps , Status = AccountStatus.Disabled};
                Assert.IsFalse(_paymentRule.IsPaymentAllowed(nonLiveChapsAccount, testAmount));
            }
            [TestMethod]
            public void IsPaymentAllowed_WhenAccountStatusInboundOnly_ReturnsFalse()
            {
                Account nonLiveChapsAccount = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.InboundPaymentsOnly };
                Assert.IsFalse(_paymentRule.IsPaymentAllowed(nonLiveChapsAccount, testAmount));
            }
            [TestMethod]
            public void IsPaymentAllowed_WhenAccountStatusLive_ReturnsTrue()
            {
                Account nonLiveChapsAccount = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Live };
                Assert.IsTrue(_paymentRule.IsPaymentAllowed(nonLiveChapsAccount, testAmount));
            }

            //add further tests for other payment rules

    }
}
