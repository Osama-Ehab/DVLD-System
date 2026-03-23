using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_UiLayer.Logging;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    public class clsLocalDLA_DataAccess
    {

        // Get DTO by ID
        public static clsLocalDLADTO GetDTOByID(int id)
        {
            if (id <= 0) return null;
            clsLocalDLADTO dto = null;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID
                FROM LocalDrivingLicenseApplications
                WHERE LocalDrivingLicenseApplicationID = @ID;", conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        dto = new clsLocalDLADTO
                        {
                            LocalDLAppID = Convert.ToInt32(r["LocalDrivingLicenseApplicationID"]),
                            ApplicationID = Convert.ToInt32(r["ApplicationID"]),
                            LicenseClassID = Convert.ToByte(r["LicenseClassID"])
                        };
                    }
                }
            }
            return dto;
        }
        // Get DTO by ID
        public static clsLocalDLADTO GetDTOByBasicAppID(int applicationID)
        {
            if (applicationID <= 0) return null;
            clsLocalDLADTO dto = null;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID
                FROM LocalDrivingLicenseApplications
                WHERE ApplicationID = @applicationID;", conn))
            {
                cmd.Parameters.Add("@applicationID", SqlDbType.Int).Value = applicationID;
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        dto = new clsLocalDLADTO
                        {
                            LocalDLAppID = Convert.ToInt32(r["LocalDrivingLicenseApplicationID"]),
                            ApplicationID = Convert.ToInt32(r["ApplicationID"]),
                            LicenseClassID = Convert.ToByte(r["LicenseClassID"])
                        };
                    }
                }
            }
            return dto;
        }

        // Add
        public static int Add(clsLocalDLADTO dto)
        {
            if (dto == null) return -1;
            int newId = -1;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                VALUES (@ApplicationID, @LicenseClassID);
                SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = dto.ApplicationID;
                cmd.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = dto.LicenseClassID;
                conn.Open();
                var scalar = cmd.ExecuteScalar();
                if (scalar != null && int.TryParse(scalar.ToString(), out int id)) newId = id;
            }
            return newId;
        }

        // Update
        public static bool Update(clsLocalDLADTO dto)
        {
            if (dto == null || dto.LocalDLAppID <= 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                UPDATE LocalDrivingLicenseApplications
                SET ApplicationID = @ApplicationID, LicenseClassID = @LicenseClassID
                WHERE LocalDrivingLicenseApplicationID = @ID;", conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = dto.LocalDLAppID;
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = dto.ApplicationID;
                cmd.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = dto.LicenseClassID;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Delete
        public static bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID;", conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Exists by LocalDLAppID
        public static bool Exists(int id)
        {
            if (id <= 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("SELECT 1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID;", conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                conn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        // Exists by ApplicationID
        public static bool IsApplicationIDExist(int applicationId)
        {
            if (applicationId <= 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("SELECT 1 FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID;", conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationId;
                conn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        // GetAll DTOs
        public static List<clsLocalDLADTO> GetAllDTOs()
        {
            var list = new List<clsLocalDLADTO>();
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("SELECT LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID FROM LocalDrivingLicenseApplications ORDER BY LocalDrivingLicenseApplicationID DESC;", conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new clsLocalDLADTO
                        {
                            LocalDLAppID = Convert.ToInt32(r["LocalDrivingLicenseApplicationID"]),
                            ApplicationID = Convert.ToInt32(r["ApplicationID"]),
                            LicenseClassID = Convert.ToByte(r["LicenseClassID"])
                        });
                    }
                }
            }
            return list;
        }

        // Also return DataTable for UI convenience
        public static DataTable GetAllAsDataTable()
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("SELECT LocalDrivingLicenseApplicationID AS [L.D.L.AppID], ClassName AS [Driving Class], NationalNo AS [National No.], FullName AS [Full Name], ApplicationDate AS [Application Date], PassedTestCount AS [Passed Tests], Status FROM LocalDrivingLicenseApplications_View;", conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    dt.Load(r);
                }
            }
            return dt;
        }

        // Returns ApplicationID if same person+licenseClass has not-cancelled status (1 or 3), else -1
        public static int FindActiveDuplicateApplication(int applicantPersonID, byte? LicenseClassID)
        {
            if (applicantPersonID <= 0 || LicenseClassID == 0) return -1;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TOP(1) a.ApplicationID
                FROM Applications a
                INNER JOIN LocalDrivingLicenseApplications l ON a.ApplicationID = l.ApplicationID
                WHERE a.ApplicantPersonID = @ApplicantPersonID
                  AND l.LicenseClassID = @LicenseClassID
                  AND a.ApplicationStatus IN (1,3);", conn))
            {
                cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = applicantPersonID;
                cmd.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = LicenseClassID;
                conn.Open();
                var scalar = cmd.ExecuteScalar();
                if (scalar == null || scalar == DBNull.Value) return -1;
                return Convert.ToInt32(scalar);
            }
        }

        // =========== Test / Appointment related utilities ===========

        // Has taken test? (any test row exists for appointment/test chain)
        public static bool HasTakenTest(int localDLAppID, byte testTypeID)
        {
            if (localDLAppID <= 0 || testTypeID == 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT 1
                FROM LocalDrivingLicenseApplications l
                INNER JOIN TestAppointments ta ON l.LocalDrivingLicenseApplicationID = ta.LocalDrivingLicenseApplicationID
                WHERE l.LocalDrivingLicenseApplicationID = @LocalDLAppID
                  AND ta.TestTypeID = @TestTypeID;", conn))
            {
                cmd.Parameters.Add("@LocalDLAppID", SqlDbType.Int).Value = localDLAppID;
                cmd.Parameters.Add("@TestTypeID", SqlDbType.TinyInt).Value = testTypeID;
                conn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        // Count of tests with specific test result (true/false)
        public static int GetTakenTestCountWithResult(int localDLAppID, byte testTypeID, bool result = true)
        {
            if (localDLAppID <= 0 || testTypeID == 0) return 0;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT COUNT(*)
                FROM LocalDrivingLicenseApplications l
                INNER JOIN TestAppointments ta ON l.LocalDrivingLicenseApplicationID = ta.LocalDrivingLicenseApplicationID
                INNER JOIN Tests t ON ta.TestAppointmentID = t.TestAppointmentID
                WHERE l.LocalDrivingLicenseApplicationID = @LocalDLAppID
                  AND ta.TestTypeID = @TestTypeID
                  AND t.TestResult = @Result;", conn))
            {
                cmd.Parameters.Add("@LocalDLAppID", SqlDbType.Int).Value = localDLAppID;
                cmd.Parameters.Add("@TestTypeID", SqlDbType.TinyInt).Value = testTypeID;
                cmd.Parameters.Add("@Result", SqlDbType.Bit).Value = result;
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Check appointment status with test type and IsLocked flag (IsLocked = !isActive)
        public static bool HasAppointmentWithTestType(int localDLAppID, byte testTypeID, bool isActive = true)
        {
            if (localDLAppID <= 0 || testTypeID == 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT 1
                FROM LocalDrivingLicenseApplications l
                INNER JOIN TestAppointments ta ON l.LocalDrivingLicenseApplicationID = ta.LocalDrivingLicenseApplicationID
                WHERE l.LocalDrivingLicenseApplicationID = @LocalDLAppID
                  AND ta.TestTypeID = @TestTypeID
                  AND ta.IsLocked = @IsLocked;", conn))
            {
                cmd.Parameters.Add("@LocalDLAppID", SqlDbType.Int).Value = localDLAppID;
                cmd.Parameters.Add("@TestTypeID", SqlDbType.TinyInt).Value = testTypeID;
                cmd.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = !isActive;
                conn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        public static bool HasAnyAppointmentInSystem(int localDLAppID)
        {
            if (localDLAppID <= 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT 1
                FROM LocalDrivingLicenseApplications l
                INNER JOIN TestAppointments ta ON l.LocalDrivingLicenseApplicationID = ta.LocalDrivingLicenseApplicationID
                WHERE l.LocalDrivingLicenseApplicationID = @LocalDLAppID;", conn))
            {
                cmd.Parameters.Add("@LocalDLAppID", SqlDbType.Int).Value = localDLAppID;
                conn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {
            if (LocalDrivingLicenseApplicationID <= 0 || TestTypeID <= 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc", conn))
            {
                cmd.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                cmd.Parameters.Add("@TestTypeID", SqlDbType.TinyInt).Value = TestTypeID;
                conn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar() ?? 0);
            }
        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, byte TestTypeID)

        {

            if (LocalDrivingLicenseApplicationID <= 0 || TestTypeID <= 0) return false;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc", conn))
            {
                cmd.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                cmd.Parameters.Add("@TestTypeID", SqlDbType.TinyInt).Value = TestTypeID;
                conn.Open();
                return cmd.ExecuteScalar() != null;
            }

        }


        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, byte TestTypeID)

        {


            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }


    }
}
