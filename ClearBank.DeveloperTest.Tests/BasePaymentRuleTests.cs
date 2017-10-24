using ClearBank.DeveloperTest.BusinessRules;
using ClearBank.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ClearBank.DeveloperTest.Tests
{
    [TestClass]
    public class BasePaymentRuleTests
    {
        private BasePaymentRule _paymentRule = new BasePaymentRule();


        [TestMethod]
        public void IsAccountSuitable_WhenBacsRequestedAndBacsNotAccepted_ReturnsFalse()
        {
            Account noBacsAccount = new Account() {AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps + (int) AllowedPaymentSchemes.FasterPayments };

            Assert.IsFalse(_paymentRule.IsAccountSuitable(noBacsAccount, AllowedPaymentSchemes.Bacs));

        }

        [TestMethod]
        public void IsAccountSuitable_WhenBacsRequestedAndBacsAccepted_ReturnsTrue()
        {
            Account bacsAccount = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs  };

            Assert.IsTrue(_paymentRule.IsAccountSuitable(bacsAccount, AllowedPaymentSchemes.Bacs));
        }
    }
}
