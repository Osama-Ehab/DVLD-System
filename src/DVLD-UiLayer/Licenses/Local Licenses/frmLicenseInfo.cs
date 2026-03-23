using System;
using System.Windows.Forms;
using DVLD_UiLayer.DTOs;
using DVLD_UiLayer.HelperClasses;

namespace DVLD_UiLayer.Licenses
{
    public partial class frmLicenseInfo : Form
    {
        private readonly int? _licenseId;
        private readonly int? _applicationId;
        private readonly int? _localDLAppId;

        public int? LicenseId { get { return _licenseId; } }
        public int? ApplicationId { get { return _applicationId; } }
        public int? LocalDLAppId { get { return _localDLAppId; } }

        public frmLicenseInfo(LicenseInfoParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters),
                    "License Info Parameters cannot be null.");

            parameters.Validate();

            InitializeComponent();

            _licenseId = parameters.LicenseId;
            _applicationId = parameters.ApplicationId;
            _localDLAppId = parameters.LocalDLAppId;
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            if (LicenseId.HasValue)
            {
                DriverLicenseCard.LoadLicenseInfo(LicenseId.Value);
            }
            else if (ApplicationId.HasValue)
            {
                DriverLicenseCard.LoadLicenseInfoByApplicationID(ApplicationId.Value);
            }
            else if (LocalDLAppId.HasValue)
            {
                DriverLicenseCard.LoadLicenseInfoByLocalDL_AppID(LocalDLAppId.Value);
            }
            else
            {
                // Defensive fallback — should never happen due to guard clauses
                DriverLicenseCard.LoadLicenseInfo(-1);
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
