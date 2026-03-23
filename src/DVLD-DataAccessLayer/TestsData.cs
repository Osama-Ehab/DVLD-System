using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    public static class clsTestsDataAccess
    {

        public static clsTestDTO Find(int testID)
        {
            if (testID <= 0) return null;

            const string query = @"SELECT * FROM Tests WHERE TestID = @TestID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestID", testID);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new clsTestDTO
                        {
                            TestID = (int)reader["TestID"],
                            TestAppointmentID = (int)reader["TestAppointmentID"],
                            Notes = reader["Notes"]?.ToString() ?? string.Empty,
                            CreatedByUserID = (int)reader["CreatedByUserID"],
                            TestResult = (bool)reader["TestResult"]
                        };
                    }
                }
                catch
                {
                    return null;
                }
            }
        }


        public static clsTestDTO GetLastTestByLocalDrivingLicenseApplicaionPerTestType(clsTestAppointmentDTO dto)
        {

            if (dto == null) return null;

            string query = @"SELECT  top 1 *
                FROM           Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID                        
                        WHERE ( TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicaionID )
                        AND ( TestAppointments.TestTypeID = @TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicaionID", dto.LocalDLAppID);
                command.Parameters.AddWithValue("@TestTypeID", dto.TestTypeID);


                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new clsTestDTO
                        {
                            TestID = (int)reader["TestID"],
                            TestAppointmentID = (int)reader["TestAppointmentID"],
                            Notes = reader["Notes"]?.ToString() ?? string.Empty,
                            CreatedByUserID = (int)reader["CreatedByUserID"],
                            TestResult = (bool)reader["TestResult"]
                        };
                    }
                }
                catch
                {
                    return null;
                }

            }


        }



        public static int AddNewTest(clsTestDTO dto)
        {
            if (dto.TestAppointmentID <= 0 || dto.CreatedByUserID <= 0)
                return -1;

            const string query = @"
                INSERT INTO Tests (TestAppointmentID, Notes, CreatedByUserID, TestResult)
                VALUES (@TestAppointmentID, @Notes, @CreatedByUserID, @TestResult);
             
                UPDATE TestAppointments 
                                SET IsLocked=1 where TestAppointmentID = @TestAppointmentID;

                SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestAppointmentID", dto.TestAppointmentID);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(dto.Notes) ? (object)DBNull.Value : dto.Notes);
                command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);
                command.Parameters.AddWithValue("@TestResult", dto.TestResult);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    return (result != null && int.TryParse(result.ToString(), out int newId)) ? newId : -1;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public static bool UpdateTest(clsTestDTO dto)
        {
            if (dto.TestID <= 0)
                return false;

            const string query = @"
                UPDATE Tests
                SET Notes = @Notes,
                    TestResult = @TestResult
                WHERE TestID = @TestID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestID", dto.TestID);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(dto.Notes) ? (object)DBNull.Value : dto.Notes);
                command.Parameters.AddWithValue("@TestResult", dto.TestResult);

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

        public static bool DeleteTest(int testID)
        {
            if (testID <= 0) return false;

            const string query = "DELETE FROM Tests WHERE TestID = @TestID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestID", testID);

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

        public static DataTable GetAllTests()
        {
            const string query = "SELECT * FROM Tests";
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
                    // optional: log error
                }
            }

            return table;
        }

        public static bool IsTestExist(int testID)
        {
            if (testID <= 0) return false;

            const string query = "SELECT 1 FROM Tests WHERE TestID = @TestID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestID", testID);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsTestAppointmentExist(int testAppointmentID)
        {
            if (testAppointmentID <= 0) return false;

            const string query = "SELECT 1 FROM Tests WHERE TestAppointmentID = @TestAppointmentID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static byte PassedTestsOfLocalDL_AppID(int localDLAppID)
        {
            if (localDLAppID <= 0) return 0;

            const string query = @"
                SELECT COUNT(t.TestID)
                FROM Tests t
                INNER JOIN TestAppointments ta ON ta.TestAppointmentID = t.TestAppointmentID
                WHERE ta.LocalDrivingLicenseApplicationID = @LocalDLAppID
                AND t.TestResult = 1;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDLAppID", SqlDbType.Int).Value = localDLAppID;

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    return Convert.ToByte(result ?? 0);
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
