using DVLD_BusinessLayer.Helpers;

namespace DVLD_UiLayer.helperclasses.Validation
{
    public static class clsPasswordValidator
    {
        public static bool ValidateCurrentPassword(string EnteredPassword, string ActualPassword, out string errorMessage)
        {
            if (string.IsNullOrEmpty(EnteredPassword))
            {
                errorMessage = "Current password cannot be blank.";
                return false;
            }

            if (EnteredPassword != ActualPassword)
            {
                errorMessage = "Current password is incorrect.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateNewPassword(string newPassword, out string errorMessage)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                errorMessage = "New password cannot be blank.";
                return false;
            }

            if (!clsPasswordRules.IsStrongPassword(newPassword, out string PasswordRulesErrorMessage))
            {
                errorMessage = PasswordRulesErrorMessage;
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateConfirmPassword(string newPassword, string confirmPassword, out string errorMessage)
        {
            if (string.IsNullOrEmpty(confirmPassword))
            {
                errorMessage = "Confirmation password cannot be blank.";
                return false;
            }

            if (newPassword != confirmPassword)
            {
                errorMessage = "Passwords do not match.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
