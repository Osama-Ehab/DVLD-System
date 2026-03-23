using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    public static class clsDetainedLicensesDataAccess
    {
        public static int Add(clsDetainedLicenseDTO detainedLicense)
        {
            if (detainedLicense == null)
                return -1;

            const string query = @"
                INSERT INTO DetainedLicenses
                    (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                VALUES
                    (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased);

                SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@LicenseID", detainedLicense.LicenseID);
                command.AddParameterInferred("@DetainDate", detainedLicense.DetainDate);
                command.AddParameterInferred("@FineFees", detainedLicense.FineFees);
                command.AddParameterInferred("@CreatedByUserID", detainedLicense.CreatedByUserID);
                command.AddParameterInferred("@IsReleased", detainedLicense.IsReleased);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public static bool Update(clsDetainedLicenseDTO detainedLicense)
        {
            if (detainedLicense == null || detainedLicense.DetainID <= 0)
                return false;

            const string query = @"
                UPDATE DetainedLicenses SET
                    LicenseID = @LicenseID,
                    DetainDate = @DetainDate,
                    FineFees = @FineFees,
                    CreatedByUserID = @CreatedByUserID,
                    IsReleased = @IsReleased,
                    ReleaseDate = @ReleaseDate,
                    ReleasedByUserID = @ReleasedByUserID,
                    ReleaseApplicationID = @ReleaseApplicationID
                WHERE DetainID = @DetainID;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@DetainID", detainedLicense.DetainID);
                command.AddParameterInferred("@LicenseID", detainedLicense.LicenseID);
                command.AddParameterInferred("@DetainDate", detainedLicense.DetainDate);
                command.AddParameterInferred("@FineFees", detainedLicense.FineFees);
                command.AddParameterInferred("@CreatedByUserID", detainedLicense.CreatedByUserID);
                command.AddParameterInferred("@IsReleased", detainedLicense.IsReleased);
                command.AddParameterInferred("@ReleaseDate", detainedLicense?.ReleaseDate ?? (object)DBNull.Value);
                command.AddParameterInferred("@ReleasedByUserID", detainedLicense?.ReleasedByUserID ?? (object)DBNull.Value);
                command.AddParameterInferred("@ReleaseApplicationID", detainedLicense?.ReleaseApplicationID ??  (object)DBNull.Value);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static clsDetainedLicenseDTO GetByID(int detainID)
        {
            const string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@DetainID", detainID);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return MapReaderToDTO(reader);
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public static clsDetainedLicenseDTO GetByReleaseApplicationID(int releaseAppID)
        {
            const string query = "SELECT * FROM DetainedLicenses WHERE ReleaseApplicationID = @ReleaseApplicationID;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@ReleaseApplicationID", releaseAppID);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return MapReaderToDTO(reader);
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public static clsDetainedLicenseDTO GetByLicenseID(int licenseID)
        {
            const string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@LicenseID", licenseID);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return MapReaderToDTO(reader);
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public static DataTable GetAll()
        {
            const string query = @"select * from DetainedLicenses_View
                                   order by [Detain Date] desc";
            var table = new DataTable();

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            table.Load(reader);
                    }
                }
                catch
                {
                    // Optionally log exception
                }
            }

            return table;
        }

        public static bool Delete(int detainID)
        {
            const string query = "DELETE FROM DetainedLicenses WHERE DetainID = @DetainID;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@DetainID", detainID);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool MarkAsReleased(int detainID, int releaseAppID, int releasedByUserID)
        {
            const string query = @"
                UPDATE DetainedLicenses SET
                    IsReleased = 1,
                    ReleaseDate = @ReleaseDate,
                    ReleasedByUserID = @ReleasedByUserID,
                    ReleaseApplicationID = @ReleaseApplicationID
                WHERE DetainID = @DetainID;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@DetainID", detainID);
                command.AddParameterInferred("@ReleaseDate", DateTime.Now);
                command.AddParameterInferred("@ReleasedByUserID", releasedByUserID);
                command.AddParameterInferred("@ReleaseApplicationID", releaseAppID);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsLicenseCurrentlyDetained(int licenseID)
        {
            const string query = "SELECT 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@LicenseID", licenseID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null;
                }
                catch
                {
                    return false;
                }
            }
        }

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
