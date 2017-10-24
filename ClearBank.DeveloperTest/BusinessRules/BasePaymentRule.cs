using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.BusinessRules
{
    public class BasePaymentRule
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
