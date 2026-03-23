using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    public static class clsTestAppointmentData
    {
        // Get single record
        public static clsTestAppointmentDTO GetByID(int id)
        {
            if (id <= 0) return null;

            clsTestAppointmentDTO dto = null;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID
                FROM TestAppointments
                WHERE TestAppointmentID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dto = new clsTestAppointmentDTO
                        {
                            TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]),
                            TestTypeID = Convert.ToByte(reader["TestTypeID"]),
                            LocalDLAppID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]),
                            IsLocked = Convert.ToBoolean(reader["IsLocked"]),
                            RetakeTestAppID = reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1
                        };
                    }
                }
            }

            return dto;
        }


        public static clsTestAppointmentDTO GetLastTestAppointment(int localDLAppID, byte testTypeID)
        {
            if (localDLAppID <= 0 || testTypeID == 0)
                return null;

            clsTestAppointmentDTO dto = null;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 *
                FROM TestAppointments
                WHERE LocalDrivingLicenseApplicationID = @LocalDLAppID
                  AND TestTypeID = @TestTypeID
                ORDER BY TestAppointmentID DESC", conn))
            {
                cmd.Parameters.AddWithValue("@LocalDLAppID", localDLAppID);
                cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    dto = new clsTestAppointmentDTO
                    {
                        TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]),
                        TestTypeID = Convert.ToByte(reader["TestTypeID"]),
                        LocalDLAppID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                        AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                        CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]),
                        IsLocked = Convert.ToBoolean(reader["IsLocked"]),
                        RetakeTestAppID = reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1
                    };
                }
            }

            return dto;
        }


        // Add new appointment (returns new ID or -1)
        public static int AddNew(clsTestAppointmentDTO dto)
        {
            if (dto == null) return -1;
            if (dto.LocalDLAppID <= 0) return -1;
            if (dto.CreatedByUserID <= 0) return -1;
            // TestTypeID may be 0 if not enforced; add guard if required:
            if (dto.TestTypeID == 0) return -1;

            int newId = -1;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                INSERT INTO TestAppointments
                    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                VALUES
                    (@TestTypeID, @LocalDLAppID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestAppID);
                SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.Add("@TestTypeID", SqlDbType.TinyInt).Value = dto.TestTypeID;
                cmd.Parameters.Add("@LocalDLAppID", SqlDbType.Int).Value = dto.LocalDLAppID;
                cmd.Parameters.Add("@AppointmentDate", SqlDbType.DateTime2).Value = dto.AppointmentDate;

                var paidParam = cmd.Parameters.Add("@PaidFees", SqlDbType.Decimal);
                paidParam.Precision = 18;
                paidParam.Scale = 2;
                paidParam.Value = dto.PaidFees;

                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = dto.CreatedByUserID;
                cmd.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = dto.IsLocked;
                cmd.Parameters.Add("@RetakeTestAppID", SqlDbType.Int).Value = dto.RetakeTestAppID == -1 ? (object)DBNull.Value : dto.RetakeTestAppID;

                conn.Open();
                var scalar = cmd.ExecuteScalar();
                if (scalar != null && int.TryParse(scalar.ToString(), out int id))
                    newId = id;
            }

            return newId;
        }

        // Update appointment (currently updates AppointmentDate and IsLocked)
        public static bool Update(clsTestAppointmentDTO dto)
        {
            if (dto == null) return false;
            if (dto.TestAppointmentID <= 0) return false;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                UPDATE TestAppointments
                SET 
                    TestTypeID = @TestTypeID,
                    LocalDrivingLicenseApplicationID = @LocalDLAppID,
                    AppointmentDate = @AppointmentDate,
                    PaidFees = @PaidFees,
                    CreatedByUserID = @CreatedByUserID,
                    IsLocked = @IsLocked,
                    RetakeTestApplicationID = @RetakeTestAppID
                WHERE TestAppointmentID = @ID", conn))
            {
                cmd.Parameters.Add("@TestTypeID", SqlDbType.TinyInt).Value = dto.TestTypeID;
                cmd.Parameters.Add("@LocalDLAppID", SqlDbType.Int).Value = dto.LocalDLAppID;
                cmd.Parameters.Add("@AppointmentDate", SqlDbType.DateTime2).Value = dto.AppointmentDate;
                cmd.Parameters.Add("@PaidFees", SqlDbType.Decimal).Value = dto.PaidFees;
                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = dto.CreatedByUserID;
                cmd.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = dto.IsLocked;
                cmd.Parameters.Add("@RetakeTestAppID", SqlDbType.Int).Value = dto.RetakeTestAppID == -1 ? (object)DBNull.Value : dto.RetakeTestAppID;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = dto.TestAppointmentID;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Delete
        public static bool Delete(int id)
        {
            if (id <= 0) return false;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("DELETE FROM TestAppointments WHERE TestAppointmentID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lock appointment (sets IsLocked = 1)
        public static bool Lock(int id)
        {
            if (id <= 0) return false;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("UPDATE TestAppointments SET IsLocked = 1 WHERE TestAppointmentID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // IsExist
        public static bool IsExist(int id)
        {
            if (id <= 0) return false;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("SELECT 1 FROM TestAppointments WHERE TestAppointmentID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        // Get TestID from Tests table for a given appointment (returns -1 if none)
        public static int GetTestID(int testAppointmentID)
        {
            if (testAppointmentID <= 0) return -1;

            int testID = -1;
            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand("SELECT TestID FROM Tests WHERE TestAppointmentID = @TestAppointmentID", conn))
            {
                cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                conn.Open();
                var scalar = cmd.ExecuteScalar();
                if (scalar != null && int.TryParse(scalar.ToString(), out int id))
                    testID = id;
            }
            return testID;
        }

        // Get all as DTO list
        public static List<clsTestAppointmentDTO> GetAll()
        {
            var list = new List<clsTestAppointmentDTO>();

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID
                FROM TestAppointments
                ORDER BY AppointmentDate DESC", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new clsTestAppointmentDTO
                        {
                            TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]),
                            TestTypeID = Convert.ToByte(reader["TestTypeID"]),
                            LocalDLAppID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]),
                            IsLocked = Convert.ToBoolean(reader["IsLocked"]),
                            RetakeTestAppID = reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1
                        });
                    }
                }
            }

            return list;
        }

        // Get appointments for a specific LocalDL application; if testTypeID == 0 then ignore filter
        public static List<clsTestAppointmentDTO> GetByLocalDLAppID(int localDLAppID, byte testTypeFilter = 0)
        {
            var list = new List<clsTestAppointmentDTO>();
            if (localDLAppID <= 0) return list;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID
                FROM TestAppointments
                WHERE LocalDrivingLicenseApplicationID = @LocalDLAppID
                  AND (@TestTypeID = 0 OR TestTypeID = @TestTypeID)
                ORDER BY AppointmentDate DESC", conn))
            {
                cmd.Parameters.AddWithValue("@LocalDLAppID", localDLAppID);
                cmd.Parameters.AddWithValue("@TestTypeID", testTypeFilter);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new clsTestAppointmentDTO
                        {
                            TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]),
                            TestTypeID = Convert.ToByte(reader["TestTypeID"]),
                            LocalDLAppID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]),
                            IsLocked = Convert.ToBoolean(reader["IsLocked"]),
                            RetakeTestAppID = reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1
                        });
                    }
                }
            }

            return list;
        }

        // Get appointments by TestType (all applications)
        public static List<clsTestAppointmentDTO> GetByTestType(byte testTypeID)
        {
            var list = new List<clsTestAppointmentDTO>();
            if (testTypeID == 0) return list;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID
                FROM TestAppointments
                WHERE TestTypeID = @TestTypeID
                ORDER BY AppointmentDate DESC", conn))
            {
                cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new clsTestAppointmentDTO
                        {
                            TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]),
                            TestTypeID = Convert.ToByte(reader["TestTypeID"]),
                            LocalDLAppID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]),
                            IsLocked = Convert.ToBoolean(reader["IsLocked"]),
                            RetakeTestAppID = reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1
                        });
                    }
                }
            }

            return list;
        }

        public static DataTable GetAllAsDataTable()
        {
            var dt = new DataTable();

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID
                FROM TestAppointments
                ORDER BY AppointmentDate DESC", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            return dt;
        }

        public static DataTable GetByLocalDLAppIDAsDataTable(int localDLAppID, byte testTypeID = 0)
        {
            var dt = new DataTable();

            if (localDLAppID <= 0) return dt;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TestAppointmentID as  [Appointment ID],AppointmentDate as [Appointment Date], PaidFees as [Paid Fees], IsLocked as [Is Locked]
                FROM TestAppointments
                WHERE LocalDrivingLicenseApplicationID = @LocalDLAppID
                  AND (@TestTypeID = 0 OR TestTypeID = @TestTypeID)
                ORDER BY AppointmentDate DESC", conn))
            {
                cmd.Parameters.AddWithValue("@LocalDLAppID", localDLAppID);
                cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public static DataTable GetByTestTypeAsDataTable(byte testTypeID)
        {
            var dt = new DataTable();

            if (testTypeID == 0) return dt;

            using (var conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var cmd = new SqlCommand(@"
                SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID
                FROM TestAppointments
                WHERE TestTypeID = @TestTypeID
                ORDER BY AppointmentDate DESC", conn))
            {
                cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}
