namespace DVLD_UiLayer.DTOs
{
    public class LicenseInfoParameters
    {
        public int? LicenseId { get; set; }
        public int? ApplicationId { get; set; }
        public int? LocalDLAppId { get; set; }

        public bool HasAnyId
        {
            get
            {
                return LicenseId.HasValue || ApplicationId.HasValue || LocalDLAppId.HasValue;
            }
        }

        public void Validate()
        {
            if (!HasAnyId)
            {
                throw new System.InvalidOperationException(
                    "At least one LicenseID must be provided to load license information.");
            }
        }
    }
}
