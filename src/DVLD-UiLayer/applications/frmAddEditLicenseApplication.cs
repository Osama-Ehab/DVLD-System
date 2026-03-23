using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.ExtensionsClasses;
using DVLD_UiLayer.HelperClasses;
using DVLD_BusinessLayer.HelperClasses.Validation;
using static DVLD_UiLayer.HelperClasses.clsMessageService;
using DVLD_UiLayer.Licenses ;
using DVLD_UiLayer.UserControls;

namespace DVLD_UiLayer
{
    public partial class frmAddEditLicenseApplication : Form
    {
        private clsApplication.enApplicationType _AppType;
        public Action<int> SendApplicationID;

        public delegate void delRefreshManageBasicApplicationsList();
        public event delRefreshManageBasicApplicationsList RefreshManageBasicApplicationsList;

        event Func<bool> HandleConstraints;
        event Action SetApplicationCard;
        private enum enMode { AddNew, Update }
        private enMode _Mode;
        private bool IsAddNewMode => _Mode == enMode.AddNew;

        private int _SelectedLicenseID = -1;

        private clsInternationalLicense _NewInternationalLicnese;
        private clsLicense _SelectedLicenseInfo;
        clsApplication _SelectedLicenseApplication;

        public frmAddEditLicenseApplication(clsApplication.enApplicationType ApplicationType = clsApplication.enApplicationType.RenewDrivingLicense, int LicenseID = -1)
        {
            InitializeComponent();

            _SelectedLicenseID = LicenseID;
            _AppType = ApplicationType;
            SubscribingToValidationConstraint();
            SubscribingToSetApplicationCard();

            if (LicenseID == -1)
            {
                _Mode = enMode.AddNew;
                btnSave.Enabled = false;
                return;
            }

            _Mode = enMode.Update;
            LocalDriverLicenseCardWithFilter.LoadLicenseInfo(_SelectedLicenseID);
        }


        private void SubscribingToValidationConstraint()
        {

            switch (_AppType)
            {
                case clsApplication.enApplicationType.RenewDrivingLicense:
                    HandleConstraints += ValidateRenewApplicationConstraints;
                    break;

                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                        HandleConstraints += ValidateReleaseDetainedDrivingLicsenseApplicationConstraints;
                    break;
                case clsApplication.enApplicationType.NewInternationalLicense:
                        HandleConstraints += ValidateNewInternationlDrivingLicsenseApplicationsConstraints;
                    break;

                default:
                    HandleConstraints += ValidateNewDrivingLicsenseApplicationsConstraints;
                    break;

            }
        }
        private void SubscribingToSetApplicationCard()
        {

            switch (_AppType)
            {
                case clsApplication.enApplicationType.RenewDrivingLicense:
                    SetApplicationCard += SetRenewDrivingLicenseApplicationCard;
                        break;

                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                    SetApplicationCard += SetReleaseDrivingLicenseApplicationCard;
                    break;
                case clsApplication.enApplicationType.NewInternationalLicense:
                    SetApplicationCard += SetInternationalDrivingLicenseApplicationCard;
                    break;
                case clsApplication.enApplicationType.ReplaceDamagedDrivingLicense:
                case clsApplication.enApplicationType.ReplaceLostDrivingLicense:
                    SetApplicationCard += SetReplacementDrivingLicenseApplicationCard;
                    break;
                default:
                    break;

            }
        }
        private void frmAddEditBasicApplication_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew) LocalDriverLicenseCardWithFilter.txtLicenseIDFocus();
            ReloadFormState();
        }

        #region --- UI Setup Methods ---

        private void SetupUIState()
        {
            ConfigureVisibility();
            SetupUIForApplicationType();
        }

        private void SetupUIForApplicationType()
        {
            switch (_AppType)
            {
                case clsApplication.enApplicationType.NewInternationalLicense:
                    SetupNewInternationalLicenseUI();
                    break;

                case clsApplication.enApplicationType.RenewDrivingLicense:
                    SetupRenewLicenseUI();
                    break;

                case clsApplication.enApplicationType.ReplaceDamagedDrivingLicense:
                    SetupReplaceDamagedLicenseUI();
                    break;

                case clsApplication.enApplicationType.ReplaceLostDrivingLicense:
                    SetupReplaceLostLicenseUI();
                    break;

                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                    SetupReleaseDetainedLicenseUI();
                    break;
            }
        }
        private void ConfigureVisibility()
        {

            LocalDriverLicenseCardWithFilter.FilterEnabled = IsAddNewMode;

            bool isNewInternational = _AppType == clsApplication.enApplicationType.NewInternationalLicense;
            bool isReleaseDetained = _AppType == clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            bool isReplaceLost = _AppType == clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            bool isReplaceDamaged = _AppType == clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            bool isReplacement = isReplaceLost || isReplaceDamaged;

            InternationalApplicationCard.Visible = isNewInternational;
            NewDL_AppCard.Visible = !isNewInternational && !isReleaseDetained;
            ReleaseDetainedLicenseAppCard.Visible = isReleaseDetained;
            gbReplacementAppChoices.Visible = isReplacement;
            rbReplacementForDamaged.Checked = isReplaceDamaged;
            rbReplacementForLost.Checked = isReplaceLost;
        }

        private void SetupNewInternationalLicenseUI()
        {
            lblMode.Text = IsAddNewMode
                ? "New International Driving License Application"
                : "Update International Driving License Application";

            btnSave.Image = ImageResources.International_32;
            btnSave.Text = "Issue";
        }

        private void SetupRenewLicenseUI()
        {
            lblMode.Text = IsAddNewMode
                ? "Renew Driving License Application"
                : "Edit Renew Driving License Application";

            NewDL_AppCard.lblModeNameOfLicenseID.Text = "Renewed License ID :";
            btnSave.Image = ImageResources.IssueDrivingLicense_32;
            btnSave.Text = "Renew";
        }

        private void SetupReplaceDamagedLicenseUI()
        {
            lblMode.Text = IsAddNewMode
                ? "Replacement For Damaged Driving License Application"
                : "Edit Replacement For Damaged Driving License Application";

            NewDL_AppCard.lblModeNameOfLicenseID.Text = "Replaced License ID :";
            btnSave.Image = ImageResources.IssueDrivingLicense_32;
            btnSave.Text = "Issue Replacement";
        }

        private void SetupReplaceLostLicenseUI()
        {
            lblMode.Text = IsAddNewMode
                ? "Replacement For Lost Driving License Application"
                : "Edit Replacement For Lost Driving License Application";

            NewDL_AppCard.lblModeNameOfLicenseID.Text = "Replaced License ID :";
            btnSave.Image = ImageResources.IssueDrivingLicense_32;
            btnSave.Text = "Issue Replacement";
        }

        private void SetupReleaseDetainedLicenseUI()
        {
            lblMode.Text = IsAddNewMode
                ? "Release Detained License Application"
                : "Edit Released License Application";

            btnSave.Image = ImageResources.Release_Detained_License_32;
            btnSave.Text = "Release";
        }

        private void LoadDataForAddNewMode()
        {
            switch (_AppType)
            {
                case clsApplication.enApplicationType.NewInternationalLicense:
                    InternationalApplicationCard.LoadInternationalDL_AppInfo();
                    break;

                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                    ReleaseDetainedLicenseAppCard.LoadInfoByDetainID();
                    break;

                default:
                    NewDL_AppCard.LoadNewDL_AppInfo(_AppType);
                    break;
            }
        }

        private bool EnsureLicenseInfoLoaded()
        {
            if (_SelectedLicenseInfo == null && _SelectedLicenseID != -1)
                _SelectedLicenseInfo = clsLicense.Find(_SelectedLicenseID);
            return _SelectedLicenseInfo != null;
        }

        private bool EnsureInternationalLicenseLoaded()
        {
            if (_NewInternationalLicnese == null && _SelectedLicenseID != -1)
                _NewInternationalLicnese = clsInternationalLicense.FindByLocalLicenseID(_SelectedLicenseID);
            return _NewInternationalLicnese != null;
        }

        private void LoadDataForUpdateMode()
        {
            switch (_AppType)
            {
                case clsApplication.enApplicationType.NewInternationalLicense:
                    if (!EnsureInternationalLicenseLoaded())return;
                    InternationalApplicationCard.LoadInternationalDL_AppInfo(_SelectedLicenseApplication.ApplicationID);
                    break;

                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                    if (!EnsureLicenseInfoLoaded()) return;
                    ReleaseDetainedLicenseAppCard.LoadInfoByDetainID(_SelectedLicenseInfo.DetainedInfo.DetainID);
                    break;

                default:
                    if (!EnsureLicenseInfoLoaded()) return;
                    NewDL_AppCard.LoadNewDL_AppInfo(_AppType, _SelectedLicenseApplication.ApplicationID);

                    NewDL_AppCard.lblOldLicenseID.Text =
                        clsLicense.GetOldLicenseIDByPersonID(
                            _SelectedLicenseInfo.DriverInfo.PersonID,
                            _SelectedLicenseInfo.LicenseClassID
                        ).ToString() ?? "[???]";
                    break;
            }
        }

        private void LoadDataForCurrentMode()
        {
            if (IsAddNewMode)
            {
                LoadDataForAddNewMode();
            }
            else
            {
                LoadDataForUpdateMode();
            }
        }


        #endregion

        #region --- Validation and Constraint Handlers ---



        private bool ValidateRenewApplicationConstraints()
        {
            return HandleActiveLicenseConstraint()
                       && HandleDetainedLicenseConstraint()
                       && HandleRenewExpiredLicenseConstraint();
        }

        private bool ValidateReleaseDetainedDrivingLicsenseApplicationConstraints()
        {
            return  HandleActiveLicenseConstraint()
                        && HandleExpiredLicenseConstraint();
        }
        private bool ValidateNewInternationlDrivingLicsenseApplicationsConstraints()
        {
            return HandleActiveLicenseConstraint()
                         && HandleDetainedLicenseConstraint()
                         && HandleExpiredLicenseConstraint()
                         && HandleHasAlreadyInternationalLicenseConstraint();
        }
        private bool ValidateNewDrivingLicsenseApplicationsConstraints()
        {
            return HandleActiveLicenseConstraint()
                         && HandleDetainedLicenseConstraint()
                         && HandleExpiredLicenseConstraint();
        }

        private bool HandleHasAlreadyInternationalLicenseConstraint(Func<string, bool> onError = null,
                                            string errorMessage = "Already has an active international license with the same class. Choose a different class.")
        {
            return clsValidationRules.ValidateRule(_SelectedLicenseInfo.CanIssueInternationalLicense(), errorMessage,
                                                   onError ?? ShowConstraintError);
        }

        private bool HandleExpiredLicenseConstraint(Func<string, bool> onError = null,
                                            string errorMessage = "Local Driving License is expired.")
        {
            return clsValidationRules.ValidateRule(!_SelectedLicenseInfo.IsLicenseExpired(), errorMessage,
                                                   onError ?? ShowConstraintError);
        }

        private bool HandleActiveLicenseConstraint(Func<string, bool> onError = null,
                                                   string errorMessage = "Local Driving License is not active.")
        {
            return clsValidationRules.ValidateRule(_SelectedLicenseInfo.IsActive, errorMessage,
                                                   onError ?? ShowConstraintError) || TryResolveActiveLicenseConflict();
        }

        private bool HandleDetainedLicenseConstraint(Func<string, bool> onError = null,
                                                     string errorMessage = "Local Driving License is detained.")
        {
            return clsValidationRules.ValidateRule(!_SelectedLicenseInfo.IsDetained, errorMessage,
                                                   onError ?? ShowConstraintError);
        }

        private bool HandleRenewExpiredLicenseConstraint(Func<string, bool> onError = null,
                                                         string errorMessage = "Local Driving License is not expired yet.")
        {
            // Renewal allowed only if license IS expired
            return clsValidationRules.ValidateRule(_SelectedLicenseInfo.IsLicenseExpired(), errorMessage,
                                                   onError ?? ShowConstraintError);
        }


        private bool TryResolveActiveLicenseConflict()
        {
            int activeLicenseID = clsLicense.GetActiveLicenseIDByPersonID(
                LocalDriverLicenseCardWithFilter.SelectedLicenseInfo.DriverInfo.PersonID,
                _SelectedLicenseInfo.LicenseClassID);

            if (activeLicenseID == -1) return false;

            if (!Confirm($"There is another active license with ID = {activeLicenseID} related to the same Person and license class.\nDo you want to fetch it?",
                "Active License Found"))
            {
                return false;
            }

            LocalDriverLicenseCardWithFilter.LoadLicenseInfo(activeLicenseID);
            return true;
        }

        #endregion

        #region --- Core Logic ---

        private void SaveUpdates()
        {
            if (_SelectedLicenseInfo == null)
                return;

            if (!ValidatePreSaveConstraints())
                return;

            bool success = ProcessSaveOperation();

            if (!success)
            {
                ShowOperationFailure();
                return;
            }

            RefereshAfterSave();
        }

        private bool ProcessSaveOperation()
        {
            switch (_AppType)
            {
                case clsApplication.enApplicationType.NewInternationalLicense:
                    return SaveNewInternationalLicense();

                case clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense:
                    return SaveReleaseDetainedLicense();

                case clsApplication.enApplicationType.ReplaceDamagedDrivingLicense:
                    return SaveReplacementLicense(clsLicense.enIssueReason.DamagedReplacement);

                case clsApplication.enApplicationType.ReplaceLostDrivingLicense:
                    return SaveReplacementLicense(clsLicense.enIssueReason.LostReplacement);

                case clsApplication.enApplicationType.RenewDrivingLicense:
                    return SaveRenewedLicense();

                default:
                    return false;
            }
        }

        private bool ValidatePreSaveConstraints()
        {
            return HandleConstraints?.Invoke() ?? false;
        }

        private bool SaveNewInternationalLicense()
        {
            _NewInternationalLicnese = _SelectedLicenseInfo.IssueNewInternationalDrivingLicense(clsGlobal.CurrentUser.UserID);
            if (_NewInternationalLicnese == null) return false;

            _SelectedLicenseID = _NewInternationalLicnese.InternationalLicenseID;
            _SelectedLicenseApplication = _NewInternationalLicnese.ApplicationInfo;
            return true;
        }

        private bool SaveReleaseDetainedLicense()
        {  
            _SelectedLicenseApplication = _SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID);
            return _SelectedLicenseApplication != null;
        }

        private bool SaveReplacementLicense(clsLicense.enIssueReason reason)
        {
            _SelectedLicenseInfo = _SelectedLicenseInfo.Replace(reason, clsGlobal.CurrentUser.UserID);
            if (_SelectedLicenseInfo == null) return false;

            _SelectedLicenseID = _SelectedLicenseInfo.LicenseID;
            _SelectedLicenseApplication = _SelectedLicenseInfo.ApplicationInfo;
            return true;
        }

        private bool SaveRenewedLicense()
        {
            _SelectedLicenseInfo = _SelectedLicenseInfo.RenewLicense(_SelectedLicenseInfo.Notes, clsGlobal.CurrentUser.UserID);
            if (_SelectedLicenseInfo == null) return false;

            _SelectedLicenseID = _SelectedLicenseInfo.LicenseID;
            _SelectedLicenseApplication = _SelectedLicenseInfo.ApplicationInfo;
            return true;
        }


        private void RefereshAfterSave()
        {
            RefreshManageBasicApplicationsList?.Invoke();
            SendApplicationID?.Invoke(_SelectedLicenseID);

            _Mode = enMode.Update;

            clsApplicationMassages.ShowApplicationSuccess(_AppType, _SelectedLicenseID);
            ShowToastSuccess("Application processed successfully!");

            LoadDataForCurrentMode();
            LocalDriverLicenseCardWithFilter.FilterEnabled =
                gbReplacementAppChoices.Enabled =
                btnSave.Enabled = false;
        }

        #endregion

        #region --- Event Handlers ---

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (!Confirm("Are you sure you want to close the form and ignore changes?", "Confirm Close"))
                return;

            HandleConstraints = null;
            SetApplicationCard = null;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Confirm("Are you sure you want to save updates?", "Confirm Save"))
                return;

            if (!ValidateChildren())
            {
                ShowValidationError("Data not saved successfully because some fields are empty or invalid.");
                return;
            }

            SaveUpdates();
        }

        private void txtNumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void SelectedLocalDriverLicense_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _SelectedLicenseID == -1;
        }

        private void linklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var licensesHistory = new frmShowPersonLicenseHistory(_SelectedLicenseInfo?.DriverInfo?.PersonID ?? -1);
            licensesHistory.ShowDialog();
        }

        private void ReloadFormState()
        {
            SetupUIState();
            LoadDataForCurrentMode();
        }


        private void rbReplacement_CheckedChanged(object sender, EventArgs e)
        {
            if (!gbReplacementAppChoices.Visible) return;

            _AppType = rbReplacementForDamaged.Checked
                ? clsApplication.enApplicationType.ReplaceDamagedDrivingLicense
                : clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            ReloadFormState();
        }

        private void LocalDriverLicenseCardWithFilter_LicenseSelected(object sender, EventArgsClasses.LicenseEventArgs e)
        {
            _SelectedLicenseInfo = e.License;

            if (_SelectedLicenseInfo == null)
            {
                if (NewDL_AppCard.Visible)
                    NewDL_AppCard.ResetDefaultData();
                else if (InternationalApplicationCard.Visible)
                    InternationalApplicationCard.ResetDefaultData();
                else if (ReleaseDetainedLicenseAppCard.Visible)
                    ReleaseDetainedLicenseAppCard.ResetDefaultData();

                btnSave.Enabled = false;
                return;
            }
            if (_SelectedLicenseInfo.LicenseID == -1) return;

            _SelectedLicenseID = _SelectedLicenseInfo.LicenseID;
            _SelectedLicenseApplication = _SelectedLicenseInfo.ApplicationInfo;
            linklblShowLicensesHistory.Enabled = true;

            if (!HandleConstraints?.Invoke() ?? false)
            {
                btnSave.Enabled = false;
                return;
            }

            SetApplicationCard?.Invoke();       
            btnSave.Enabled = true;

        }

        private void SetReplacementDrivingLicenseApplicationCard()
        {
            NewDL_AppCard.lblOldLicenseID.Text = _SelectedLicenseID.ToString();
            NewDL_AppCard.lblExpirationDate.Text = _SelectedLicenseInfo.ExpirationDate.DateToShort();
            NewDL_AppCard.lblNewLicenseFees.Text = _SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString("0.00");
            NewDL_AppCard.lblTotalFees.Text =
                (_SelectedLicenseInfo.LicenseClassInfo.ClassFees + clsApplicationType.Find(Convert.ToByte(_AppType)).Fees).ToString("0.00");
        }
        private void SetInternationalDrivingLicenseApplicationCard()
        {
            InternationalApplicationCard.lblLocalLicenseID.Text = _SelectedLicenseInfo.LicenseID.ToString();
        }

        private void SetRenewDrivingLicenseApplicationCard()
        {
            NewDL_AppCard.lblOldLicenseID.Text = _SelectedLicenseID.ToString();
            NewDL_AppCard.lblExpirationDate.Text = DateTime.Now.AddYears(_SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength).DateToShort();
            NewDL_AppCard.lblNewLicenseFees.Text = _SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString("0.00");
            NewDL_AppCard.lblTotalFees.Text =
                (_SelectedLicenseInfo.LicenseClassInfo.ClassFees + clsApplicationType.Find(Convert.ToByte(_AppType)).Fees).ToString("0.00");
        }

        private void SetReleaseDrivingLicenseApplicationCard()
        {
            ReleaseDetainedLicenseAppCard.lblDetainedLicenseID.Text = _SelectedLicenseID.ToString();
            ReleaseDetainedLicenseAppCard.lblDetainID.Text = _SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            ReleaseDetainedLicenseAppCard.lblFineFees.Text = _SelectedLicenseInfo.DetainedInfo.FineFees.ToString("0.00");
            ReleaseDetainedLicenseAppCard.lblTotalFees.Text =
                (_SelectedLicenseInfo.DetainedInfo.FineFees + clsApplicationType.Find(Convert.ToByte(_AppType)).Fees).ToString("0.00");
        }

        private bool ShowConstraintError(string message)
        {
            ShowError(message);
            btnSave.Enabled = false;
            return false;
        }

        private void ShowOperationFailure()
        {
            clsApplicationMassages.ShowApplicationFailure(_AppType);
            ShowToastError("Operation failed!");
        }

        #endregion


    }
}
