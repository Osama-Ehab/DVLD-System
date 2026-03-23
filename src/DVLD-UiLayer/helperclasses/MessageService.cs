using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_UiLayer.HelperClasses
{
    public static class clsMessageService
    {
        #region Standard MessageBoxes

        public static void ShowError(string message, string title = "Error") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool ShowErrorReturnBoolean(string message, string title = "Error",bool returnValue = false)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return returnValue;
        }

        public static void ShowValidationError(string message) =>
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowInfo(string message, string title = "Info") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowSuccess(string message, string title = "Success") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowWarning(string message, string title = "Warning") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static bool Confirm(string message, string title = "Confirm") =>
            MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;

        #endregion

        #region Toast Notifications

        public static void ShowToast(string message, string title = "", int duration = 3000, Color? backColor = null, Color? foreColor = null)
        {
            var toast = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                TopMost = true,
                BackColor = backColor ?? Color.FromArgb(50, 50, 50),
                Size = new Size(300, 80),
                Opacity = 0.95,
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = foreColor ?? Color.White,
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 9),
                ForeColor = foreColor ?? Color.WhiteSmoke,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            toast.Controls.Add(lblMessage);
            toast.Controls.Add(lblTitle);

            // Position in bottom-right corner of primary screen
            var screen = Screen.PrimaryScreen.WorkingArea;
            toast.Location = new Point(screen.Right - toast.Width - 20, screen.Bottom - toast.Height - 20);

            toast.Shown += (s, e) =>
            {
                var timer = new System.Windows.Forms.Timer { Interval = duration };
                timer.Tick += (sender, args) =>
                {
                    timer.Stop();
                    toast.Close();
                };
                timer.Start();
            };

            toast.Show();
        }

        public static void ShowToastInfo(string message, string title = "Information", int duration = 3000) =>
            ShowToast(message, title, duration, Color.FromArgb(40, 110, 180));

        public static void ShowToastSuccess(string message, string title = "Success", int duration = 3000) =>
            ShowToast(message, title, duration, Color.FromArgb(0, 128, 0));

        public static void ShowToastWarning(string message, string title = "Warning", int duration = 3000) =>
            ShowToast(message, title, duration, Color.FromArgb(255, 165, 0));

        public static void ShowToastError(string message, string title = "Error", int duration = 3000) =>
            ShowToast(message, title, duration, Color.FromArgb(178, 34, 34));

        #endregion
    }
}
