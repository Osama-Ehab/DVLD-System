using System;
using DVLD_UiLayer.Logging;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    public static class clsInternationalLicensesDataAccess
    {
        // Return DTO or null if not found
        public static clsInternationalLicenseDTO GetInternationalLicenseByID(int id)
        {
            if (id <= 0) return null;

            const string query = @"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                          IssueDate, ExpirationDate, IsActive, CreatedByUserID
                                   FROM InternationalLicenses
                                   WHERE InternationalLicenseID = @InternationalLicenseID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@InternationalLicenseID", id);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var dto = new clsInternationalLicenseDTO
                        {
                            InternationalLicenseID = (int)reader["InternationalLicenseID"],
                            ApplicationID = (int)reader["ApplicationID"],
                            DriverID = (int)reader["DriverID"],
                            IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                            IssueDate = (DateTime)reader["IssueDate"],
                            ExpirationDate = (DateTime)reader["ExpirationDate"],
                            IsActive = (bool)reader["IsActive"],
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };

                        return dto;
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    // optionally log
                    return null;
                }
            }
        }

        public static clsInternationalLicenseDTO GetInternationalLicenseByApplicationID(int applicationID)
        {
            if (applicationID <= 0) return null;

            const string query = @"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                          IssueDate, ExpirationDate, IsActive, CreatedByUserID
                                   FROM InternationalLicenses
                                   WHERE ApplicationID = @ApplicationID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@ApplicationID", applicationID);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var dto = new clsInternationalLicenseDTO
                        {
                            InternationalLicenseID = (int)reader["InternationalLicenseID"],
                            ApplicationID = (int)reader["ApplicationID"],
                            DriverID = (int)reader["DriverID"],
                            IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                            IssueDate = (DateTime)reader["IssueDate"],
                            ExpirationDate = (DateTime)reader["ExpirationDate"],
                            IsActive = (bool)reader["IsActive"],
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };

                        return dto;
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return null;
                }
            }
        }

        public static clsInternationalLicenseDTO GetInternationalLicenseByLocalLicenseID(int localLicenseID)
        {
            if (localLicenseID <= 0) return null;

            const string query = @"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                          IssueDate, ExpirationDate, IsActive, CreatedByUserID
                                   FROM InternationalLicenses
                                   WHERE IssuedUsingLocalLicenseID = @LocalLicenseID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@LocalLicenseID", localLicenseID);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var dto = new clsInternationalLicenseDTO
                        {
                            InternationalLicenseID = (int)reader["InternationalLicenseID"],
                            ApplicationID = (int)reader["ApplicationID"],
                            DriverID = (int)reader["DriverID"],
                            IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                            IssueDate = (DateTime)reader["IssueDate"],
                            ExpirationDate = (DateTime)reader["ExpirationDate"],
                            IsActive = (bool)reader["IsActive"],
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };

                        return dto;
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return null;
                }
            }
        }

        public static DataTable GetAllInternationalLicenses()
        {
            var dt = new DataTable();
            const string query = @"SELECT
                                 InternationalLicenseID AS [Int.License ID],
                                 ApplicationID AS [Application ID],
                                 DriverID AS [Driver ID],
                                 IssuedUsingLocalLicenseID AS [L.License ID],
                                 IssueDate AS [Issue Date],
                                 ExpirationDate AS [Expiration Date],
                                 IsActive AS [Is Active]
                             FROM InternationalLicenses;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt.Load(reader);
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                }
            }

            return dt;
        }

        public static DataTable GetAllInternationalLicensesRelatedToPersonID(int personID)
        {
            if (personID <= 0) return new DataTable();

            var dt = new DataTable();
            const string query = @"SELECT InternationalLicenses.InternationalLicenseID as [Int.License ID],
                                               InternationalLicenses.ApplicationID as [Application ID],
                                               InternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID],
                                               InternationalLicenses.IssueDate AS [Issue Date],
                                               InternationalLicenses.ExpirationDate AS [Expiration Date],
                                               InternationalLicenses.IsActive AS [Is Active]
                             FROM InternationalLicenses
                             INNER JOIN Drivers ON InternationalLicenses.DriverID = Drivers.DriverID
                             INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID AND Drivers.DriverID = Licenses.DriverID
                             WHERE Drivers.PersonID = @PersonID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@PersonID", personID);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt.Load(reader);
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                }
            }

            return dt;
        }

        public static DataTable GetAllInternationalLicensesRelatedToDriverID(int driverID)
        {
            if (driverID <= 0) return new DataTable();

            var dt = new DataTable();
            const string query = @"SELECT InternationalLicenses.InternationalLicenseID as [Int.License ID],
                                               InternationalLicenses.ApplicationID as [Application ID],
                                               InternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID],
                                               InternationalLicenses.IssueDate AS [Issue Date],
                                               InternationalLicenses.ExpirationDate AS [Expiration Date],
                                               InternationalLicenses.IsActive AS [Is Active]
                             FROM InternationalLicenses
                             INNER JOIN Drivers ON InternationalLicenses.DriverID = Drivers.DriverID
                             INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID AND Drivers.DriverID = Licenses.DriverID
                             WHERE Drivers.DriverID = @DriverID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@DriverID", driverID);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt.Load(reader);
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                }
            }

            return dt;
        }

        public static int AddNewInternationalLicense(clsInternationalLicenseDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            if (dto.DriverID <= 0) throw new ArgumentException("DriverID must be > 0", "dto.DriverID");

            const string query = @"
                             UPDATE InternationalLicenses
                               SET IsActive = 0
                               WHERE DriverID = @DriverID;

                             INSERT INTO [dbo].[InternationalLicenses]
                             (
                                 [ApplicationID],
                                 [DriverID],
                                 [IssuedUsingLocalLicenseID],
                                 [IssueDate],
                                 [ExpirationDate],
                                 [IsActive],
                                 [CreatedByUserID]
                             )
                             VALUES
                             (
                                 @ApplicationID,
                                 @DriverID,
                                 @IssuedUsingLocalLicenseID,
                                 @IssueDate,
                                 @ExpirationDate,
                                 @IsActive,
                                 @CreatedByUserID
                             );
                             SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@ApplicationID", dto.ApplicationID);
                command.AddParameterInferred("@DriverID", dto.DriverID);
                command.AddParameterInferred("@IssuedUsingLocalLicenseID", dto.IssuedUsingLocalLicenseID);
                command.AddParameterInferred("@IssueDate", dto.IssueDate);
                command.AddParameterInferred("@ExpirationDate", dto.ExpirationDate);
                command.AddParameterInferred("@IsActive", dto.IsActive);
                command.AddParameterInferred("@CreatedByUserID", dto.CreatedByUserID);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                        return id;
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    // optionally log
                }
            }

            return -1;
        }

        public static bool UpdateInternationalLicense(clsInternationalLicenseDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            if (dto.InternationalLicenseID <= 0) throw new ArgumentException("InternationalLicenseID must be > 0", "dto.InternationalLicenseID");

            const string query = @"
                             UPDATE InternationalLicenses
                             SET
                                 [ApplicationID] = @ApplicationID,
                                 [DriverID] = @DriverID,
                                 [IssuedUsingLocalLicenseID] = @IssuedUsingLocalLicenseID,
                                 [ExpirationDate] = @ExpirationDate,
                                 [CreatedByUserID] = @CreatedByUserID,
                                 [IsActive] = @IsActive
                             WHERE
                                 InternationalLicenseID = @InternationalLicenseID;";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@InternationalLicenseID", dto.InternationalLicenseID);
                command.AddParameterInferred("@ApplicationID", dto.ApplicationID);
                command.AddParameterInferred("@DriverID", dto.DriverID);
                command.AddParameterInferred("@IssuedUsingLocalLicenseID", dto.IssuedUsingLocalLicenseID);
                command.AddParameterInferred("@ExpirationDate", dto.ExpirationDate);
                command.AddParameterInferred("@CreatedByUserID", dto.CreatedByUserID);
                command.AddParameterInferred("@IsActive", dto.IsActive);

                try
                {
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return false;
                }
            }
        }

        public static bool DeleteInternationalLicense(int id)
        {
            if (id <= 0) return false;

            const string query = @"DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@InternationalLicenseID", id);

                try
                {
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return false;
                }
            }
        }

        public static bool IsInternationalLicenseExist(int id)
        {
            if (id <= 0) return false;

            const string query = "SELECT 1 FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@InternationalLicenseID", id);
                try
                {
                    connection.Open();
                    return (command.ExecuteScalar() != null);
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return false;
                }
            }
        }

        public static bool IsInternationalLicenseDetained(int id)
        {
            if (id <= 0) return false;

            const string query = @"SELECT 1 FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID AND IsReleased = 0";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@InternationalLicenseID", id);
                try
                {
                    connection.Open();
                    return (command.ExecuteScalar() != null);
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return false;
                }
            }
        }

        public static bool IsPersonIDHaveAnActiveInternationalLicenseWithL_ClassID(int personID, byte? licenseClassID)
        {
            if (personID <= 0 || licenseClassID == null) return false;

            const string query = @"SELECT 1
                             FROM InternationalLicenses
                             INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID
                             INNER JOIN Drivers ON InternationalLicenses.DriverID = Drivers.DriverID
                             WHERE Licenses.LicenseClassID = @LicenseClassID AND Drivers.PersonID = @PersonID and InternationalLicenses.IsActive = 1";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@PersonID", personID);
                command.AddParameterInferred("@LicenseClassID", licenseClassID);

                try
                {
                    connection.Open();
                    return (command.ExecuteScalar() != null);
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return false;
                }
            }
        }

        public static bool IsDriverIDHaveAnActiveInternationalLicenseWithL_ClassID(int driverID, byte? licenseClassID)
        {
            if (driverID <= 0 || licenseClassID == null) return false;

            const string query = @"SELECT 1
                             FROM InternationalLicenses
                             INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID
                             INNER JOIN Drivers ON InternationalLicenses.DriverID = Drivers.DriverID
                             WHERE Licenses.LicenseClassID = @LicenseClassID AND Drivers.DriverID = @DriverID and InternationalLicenses.IsActive = 1";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@DriverID", driverID);
                command.AddParameterInferred("@LicenseClassID", licenseClassID);

                try
                {
                    connection.Open();
                    return (command.ExecuteScalar() != null);
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return false;
                }
            }
        }

        public static bool IsApplicationIDExist(int applicationID)
        {
            if (applicationID <= 0) return false;

            const string query = "SELECT 1 FROM InternationalLicenses WHERE ApplicationID = @ApplicationID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@ApplicationID", applicationID);
                try
                {
                    connection.Open();
                    return (command.ExecuteScalar() != null);
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    return false;
                }
            }
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int driverID)
        {
            if (driverID <= 0) return -1;

            const string query = @"SELECT TOP 1 InternationalLicenseID
                                   FROM InternationalLicenses
                                   WHERE DriverID = @DriverID AND GETDATE() BETWEEN IssueDate AND ExpirationDate AND IsActive = 1
                                   ORDER BY ExpirationDate DESC";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.AddParameterInferred("@DriverID", driverID);
                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                        return id;
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                }
            }

            return -1;
        }
    }
}

