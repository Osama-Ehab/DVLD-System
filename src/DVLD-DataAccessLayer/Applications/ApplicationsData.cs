using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
   

    public static class clsApplicationData
    {
        // Add new application (DOES NOT accept status/date from caller).
        // DB will set ApplicationDate, LastStatusDate and ApplicationStatus (set to New).
        public static int AddNewApplication(clsApplicationDTO dto)
        {
            if (dto == null) return -1;
            if (dto.ApplicantPersonID <= 0) return -1;
            if (dto.ApplicationTypeID <= 0) return -1;
            if (dto.CreatedByUserID <= 0) return -1;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                    INSERT INTO Applications
                        (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                    VALUES
                        (@ApplicantPersonID, SYSDATETIME(), @ApplicationTypeID, @ApplicationStatus, SYSDATETIME(), @PaidFees, @CreatedByUserID);
                    SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = dto.ApplicantPersonID;
                cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.TinyInt).Value = dto.ApplicationTypeID;

                var paidParam = cmd.Parameters.Add("@PaidFees", SqlDbType.Decimal);
                paidParam.Precision = 18;
                paidParam.Scale = 2;
                paidParam.Value = dto.PaidFees;

                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = dto.CreatedByUserID;

                // Explicitly set status to New (1) at insert time; caller should not provide it.
                cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = (byte)1;

                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result == null || !int.TryParse(result.ToString(), out int insertedId)) return -1;

                return insertedId;
            }
        }

        // Update application (includes ApplicationStatus)
        public static bool UpdateApplication(clsApplicationDTO dto)
        {
            if (dto == null) return false;
            if (dto.ApplicationID <= 0) return false;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                    UPDATE Applications
                    SET ApplicantPersonID = @ApplicantPersonID,
                        ApplicationTypeID = @ApplicationTypeID,
                        ApplicationStatus = @ApplicationStatus,
                        PaidFees = @PaidFees,
                        CreatedByUserID = @CreatedByUserID
                    WHERE ApplicationID = @ApplicationID;", conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = dto.ApplicationID;
                cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = dto.ApplicantPersonID;
                cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.TinyInt).Value = dto.ApplicationTypeID;
                cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = dto.ApplicationStatus;

                var paidParam = cmd.Parameters.Add("@PaidFees", SqlDbType.Decimal);
                paidParam.Precision = 18;
                paidParam.Scale = 2;
                paidParam.Value = dto.PaidFees;

                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = dto.CreatedByUserID;

                conn.Open();
                if (cmd.ExecuteNonQuery() <= 0) return false;
                return true;
            }
        }

        // Delete application
        public static bool DeleteApplication(int applicationId)
        {
            if (applicationId <= 0) return false;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("DELETE FROM Applications WHERE ApplicationID = @ApplicationID;", conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationId;
                conn.Open();
                if (cmd.ExecuteNonQuery() <= 0) return false;
                return true;
            }
        }

        // Update status (DB will update LastStatusDate via SYSDATETIME() in this statement)
        public static bool UpdateStatus(int applicationId, byte status)
        {
            if (applicationId <= 0) return false;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                    UPDATE Applications
                    SET ApplicationStatus = @Status,
                        LastStatusDate = SYSDATETIME()
                    WHERE ApplicationID = @ApplicationID;", conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationId;
                cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = status;

                conn.Open();
                if (cmd.ExecuteNonQuery() <= 0) return false;
                return true;
            }
        }

        // Existence check
        public static bool IsApplicationExist(int applicationId)
        {
            if (applicationId <= 0) return false;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("SELECT COUNT(1) FROM Applications WHERE ApplicationID = @ApplicationID;", conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationId;
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count <= 0) return false;
                return true;
            }
        }

        // Get single application by ID (reads by column name)
        public static clsApplicationDTO GetApplicationByID(int applicationId)
        {
            if (applicationId <= 0) return null;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                    SELECT ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                           ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID
                    FROM Applications
                    WHERE ApplicationID = @ApplicationID;", conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationId;
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    var dto = new clsApplicationDTO
                    {
                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                        ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]),
                        ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]),
                        ApplicationTypeID = Convert.ToByte(reader["ApplicationTypeID"]),
                        ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]),
                        LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]),
                        PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                        CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"])
                    };

                    return dto;
                }
            }
        }

        // Get all applications (returns list of DTOs)
        public static List<clsApplicationDTO> GetAllApplications()
        {
            var list = new List<clsApplicationDTO>();

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                    SELECT ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                           ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID
                    FROM Applications
                    ORDER BY ApplicationDate DESC;", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dto = new clsApplicationDTO
                        {
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                            ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]),
                            ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]),
                            ApplicationTypeID = Convert.ToByte(reader["ApplicationTypeID"]),
                            ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]),
                            LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]),
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"])
                        };
                        list.Add(dto);
                    }
                }
            }

            return list;
        }

        // Returns the active application ID for a person+type (or -1 if none)
        public static int GetActiveApplicationID(int personId, byte applicationTypeId)
        {
            if (personId <= 0) return -1;
            if (applicationTypeId <= 0) return -1;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                    SELECT TOP(1) ApplicationID
                    FROM Applications
                    WHERE ApplicantPersonID = @PersonID
                      AND ApplicationTypeID = @ApplicationTypeID
                      AND ApplicationStatus = 1;", conn)) // 1 = New (active)
            {
                cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = personId;
                cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.TinyInt).Value = applicationTypeId;

                conn.Open();
                var scalar = cmd.ExecuteScalar();
                if (scalar == null || scalar == DBNull.Value) return -1;
                return Convert.ToInt32(scalar);
            }
        }

        // Active application for license class
        public static int GetActiveApplicationIDForLicenseClass(int personId, byte applicationTypeId, byte? LicenseClassID)
        {
            if (personId <= 0) return -1;
            if (applicationTypeId <= 0) return -1;
            if (LicenseClassID == null) return -1;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                    SELECT TOP(1) a.ApplicationID
                    FROM Applications a
                    INNER JOIN LocalDrivingLicenseApplications l ON a.ApplicationID = l.ApplicationID
                    WHERE a.ApplicantPersonID = @PersonID
                      AND a.ApplicationTypeID = @ApplicationTypeID
                      AND l.LicenseClassID = @LicenseClassID
                      AND a.ApplicationStatus = 1;", conn))
            {
                cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = personId;
                cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.TinyInt).Value = applicationTypeId;
                cmd.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                conn.Open();
                var scalar = cmd.ExecuteScalar();
                if (scalar == null || scalar == DBNull.Value) return -1;
                return Convert.ToInt32(scalar);
            }
        }


      
    }
}

