using DVLD_DataAccessLayer.DTOs;
using Microsoft.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    internal static class clsDetainedLicensesDataAccessHelpers
    {

        private static clsDetainedLicenseDTO MapReaderToDTO(SqlDataReader reader)
        {
            var dto = new clsDetainedLicenseDTO();

            dto.DetainID = Convert.ToInt32(reader["DetainID"]);
            dto.LicenseID = Convert.ToInt32(reader["LicenseID"]);
            dto.DetainDate = Convert.ToDateTime(reader["DetainDate"]);
            dto.FineFees = Convert.ToDecimal(reader["FineFees"]);
            dto.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
            dto.IsReleased = Convert.ToBoolean(reader["IsReleased"]);
            dto.ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ReleaseDate"]);
            dto.ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReleasedByUserID"]);
            dto.ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReleaseApplicationID"]);

            return dto;
        }
    }
}