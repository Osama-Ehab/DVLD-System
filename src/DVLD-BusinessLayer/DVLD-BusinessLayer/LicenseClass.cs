using System;
using System.Data;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClass
    {
        private enum enMode { AddNew, Update }
        private enMode _mode = enMode.AddNew;

        public enum SaveResult
        {
            Success,
            ValidationFailed,
            DbError
        }

        public byte? LicenseClassID { get; private set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }

        [Range<byte>(18, 21)]
        public byte MinimumAllowedAge { get; set; }

        [Range<byte>(1,10)]
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        // placeholder for lazy-loaded related data if needed later
        // private SomeType _related;

        public clsLicenseClass()
        {
            LicenseClassID = 3;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 18;
            DefaultValidityLength = 10;
            ClassFees = 0m;
            _mode = enMode.AddNew;
        }

        private clsLicenseClass(clsLicenseClassDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            LicenseClassID = dto.LicenseClassID;
            ClassName = dto.ClassName;
            ClassDescription = dto.ClassDescription;
            MinimumAllowedAge = dto.MinimumAllowedAge;
            DefaultValidityLength = dto.DefaultValidityLength;
            ClassFees = dto.ClassFees;
            _mode = enMode.Update;
        }

        private clsLicenseClassDTO ToDTO() => new clsLicenseClassDTO
        {
            LicenseClassID = LicenseClassID,
            ClassName = ClassName,
            ClassDescription = ClassDescription,
            MinimumAllowedAge = MinimumAllowedAge,
            DefaultValidityLength = DefaultValidityLength,
            ClassFees = ClassFees
        };

        private bool AddNew()
        {
            if (string.IsNullOrWhiteSpace(ClassName) || MinimumAllowedAge == 0) return false;

            var dto = ToDTO();
            byte? newId = clsLicenseClassesDataAccess.AddNewLicenseClass(dto);
            if (newId == -1) return false;

            LicenseClassID = newId;
            _mode = enMode.Update;
            return true;
        }

        private bool Update()
        {
            if (LicenseClassID == null) return false;

            var dto = ToDTO();
            return clsLicenseClassesDataAccess.UpdateLicenseClass(dto);
        }

        public SaveResult Save()
        {
            if (string.IsNullOrWhiteSpace(ClassName) || MinimumAllowedAge == 0)
                return SaveResult.ValidationFailed;

            bool success = (_mode == enMode.AddNew) ? AddNew() : Update();
            return success ? SaveResult.Success : SaveResult.DbError;
        }

        public static bool Delete(byte? LicenseClassID)
        {
            if (LicenseClassID == null) return false;
            return clsLicenseClassesDataAccess.DeleteLicenseClass(LicenseClassID);
        }

        public static clsLicenseClass Find(byte? LicenseClassID)
        {
            if (LicenseClassID == null) return null;
            var dto = clsLicenseClassesDataAccess.Find(LicenseClassID);
            return dto != null ? new clsLicenseClass(dto) : null;
        }

        public static clsLicenseClass FindByName(string className)
        {
            if (string.IsNullOrWhiteSpace(className)) return null;
            var dto = clsLicenseClassesDataAccess.FindByName(className);
            return dto != null ? new clsLicenseClass(dto) : null;
        }

        public static bool IsExist(byte? LicenseClassID) => clsLicenseClassesDataAccess.IsExist(LicenseClassID);
        public static DataTable GetAll() => clsLicenseClassesDataAccess.GetAllLicenseClasses();
    }
}
