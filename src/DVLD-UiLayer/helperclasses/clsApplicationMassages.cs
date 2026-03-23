using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_UiLayer.HelperClasses
{
    public static class clsApplicationMassages
    {
        public static void ShowApplicationSuccess(clsApplication.enApplicationType appType, int licenseID)
        {
            string message;

            switch (appType)
            {
                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                    message = $"The License with ID = {licenseID} was released successfully.";
                    break;

                case clsApplication.enApplicationType.NewDrivingLicense:
                    message = $"Data saved successfully. The new License ID = {licenseID}.";
                    break;

                case clsApplication.enApplicationType.RenewDrivingLicense:
                    message = $"The License with ID = {licenseID} was renewed successfully.";
                    break;

                case clsApplication.enApplicationType.ReplaceDamagedDrivingLicense:
                    message = $"Replacement for damaged License (ID = {licenseID}) saved successfully.";
                    break;

                case clsApplication.enApplicationType.ReplaceLostDrivingLicense:
                    message = $"Replacement for lost License (ID = {licenseID}) saved successfully.";
                    break;

                default:
                    message = $"Data saved successfully. License ID = {licenseID}.";
                    break;
            }

            clsMessageService.ShowSuccess(message);
        }

        // ==================================
        // ❌ Shared Failure Message
        // ==================================
        public static void ShowApplicationFailure(clsApplication.enApplicationType appType)
        {
            string message;
            const string title = "Error";

            switch (appType)
            {
                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                    message = "Failed to release the detained license. Please try again.";
                    break;

                case clsApplication.enApplicationType.NewDrivingLicense:
                    message = "Failed to issue the new driving license.";
                    break;

                case clsApplication.enApplicationType.RenewDrivingLicense:
                    message = "Failed to renew the driving license.";
                    break;

                case clsApplication.enApplicationType.ReplaceDamagedDrivingLicense:
                    message = "Failed to replace the damaged driving license.";
                    break;

                case clsApplication.enApplicationType.ReplaceLostDrivingLicense:
                    message = "Failed to replace the lost driving license.";
                    break;

                case clsApplication.enApplicationType.NewInternationalLicense:
                    message = "Failed to issue the international driving license.";
                    break;

                default:
                    message = "Data not saved successfully.";
                    break;
            }

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
