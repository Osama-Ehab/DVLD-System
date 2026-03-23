using System;
using System.Linq;

namespace DVLD_BusinessLayer.Helpers
{
    public static class clsPasswordRules
    {
        /// <summary>
        /// Validation Password if is apply the strong Password Standers.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="errorMessage"></param>
        /// <returns>True if Follow Password Standers,false otherwise.</returns>
        public static bool IsStrongPassword(string password, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Password cannot be blank.";
                return false;
            }

            if (password.Length < 8)
            {
                errorMessage = "Password must be at least 8 characters long.";
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                errorMessage = "Password must contain at least one uppercase letter.";
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                errorMessage = "Password must contain at least one lowercase letter.";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                errorMessage = "Password must contain at least one digit.";
                return false;
            }

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                errorMessage = "Password must contain at least one special character (!@#$%^&* etc.).";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
