using System;

namespace DVLD_UiLayer.HelperClasses
{
    public static class clsFilterHelper
    {
        /// <summary>
        /// Secures a text string before applying it in a DataView.RowFilter expression.
        /// Escapes special characters like quotes, brackets, and wildcards to prevent filter errors.
        /// </summary>
        public static string SecureFilterText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Escape all reserved characters used in RowFilter expressions
            string safe = input.Trim().Replace("'", "''")
                               .Replace("[", "[[]")
                               .Replace("]", "[]]")
                               .Replace("%", "[%]")
                               .Replace("*", "[*]")
                               .Replace("_", "[_]");
            return safe;
        }
    }
}
