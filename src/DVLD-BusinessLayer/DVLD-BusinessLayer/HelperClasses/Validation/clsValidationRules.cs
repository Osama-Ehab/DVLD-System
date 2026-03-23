using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer.HelperClasses.Validation
{
    public static class clsValidationRules
    {
        public static bool ValidateRule(bool condition, string errorMessage, Func<string, bool> onError = null)
        {
            return condition || (onError?.Invoke(errorMessage) ?? false);
        }
    }
}
