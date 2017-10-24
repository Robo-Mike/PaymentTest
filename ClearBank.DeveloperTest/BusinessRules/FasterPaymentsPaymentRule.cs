using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class FasterPaymentsPaymentRule:BasePaymentRule, IPaymentRule
    {
        public bool IsPaymentAllowed(Account account, decimal amount)
        {
            if (this.IsAccountSuitable(account,AllowedPaymentSchemes.FasterPayments) 
                && account.Balance >= amount)
            {
                return true;
            }

            return false;
        }
    }
}
