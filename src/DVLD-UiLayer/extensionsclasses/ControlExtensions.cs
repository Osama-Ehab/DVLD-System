using System;
using System.Windows.Forms;

namespace DVLD_UiLayer.Helpers
{
    public static class clsControlExtensions
    {
      
        public static void SetErrorAndFocus(this Control control, ErrorProvider errorProvider, string message)
        {
            errorProvider?.SetError(control, message);
            control?.Focus();
        }

        public static void ClearError(this Control control, ErrorProvider errorProvider)
        {
            errorProvider?.SetError(control, string.Empty);
        }

        public static void HandleEnterKey(this Control control, Action action)
        {
            control.KeyDown += (sender, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;

                e.Handled = true;
                e.SuppressKeyPress = true;
                action?.Invoke();
            };
        }
    }
}
