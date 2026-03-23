using System;
using DVLD_UiLayer.Logging;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_DataAccessLayer.Repository.Settings;


namespace DVLD_DataAccessLayer
{
    public class clsLicenseData
    {
        // Return DTO or null if not found
        public static clsLicenseDTO GetLicenseByID(int licenseID)
        {
            if (licenseID <= 0) return null;

            const string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClassID,
                                          IssueDate, ExpirationDate, Notes, PaidFees,
                                          IsActive, IssueReason, CreatedByUserID
                                   FROM Licenses
                                   WHERE LicenseID = @LicenseID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var dto = new clsLicenseDTO
                        {
                            LicenseID = (int)reader["LicenseID"],
                            ApplicationID = (int)reader["ApplicationID"],
                            DriverID = (int)reader["DriverID"],
                            LicenseClassID = Convert.ToByte(reader["LicenseClassID"]),
                            IssueDate = (DateTime)reader["IssueDate"],
                            ExpirationDate = (DateTime)reader["ExpirationDate"],
                            Notes = reader["Notes"] == DBNull.Value ? string.Empty : (string)reader["Notes"],
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                            IsActive = (bool)reader["IsActive"],
                            IssueReason = Convert.ToByte(reader["IssueReason"]),
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };

                        return dto;
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    // Optionally log the exception here
                    return null;
                }
            }
        }

        public static clsLicenseDTO GetLicenseBApplicationID(int ApplicationID)
        {
            if (ApplicationID <= 0) return null;

            const string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClassID,
                                          IssueDate, ExpirationDate, Notes, PaidFees,
                                          IsActive, IssueReason, CreatedByUserID
                                   FROM Licenses
                                   WHERE ApplicationID = @ApplicationID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        var dto = new clsLicenseDTO
                        {
                            LicenseID = (int)reader["LicenseID"],
                            ApplicationID = (int)reader["ApplicationID"],
                            DriverID = (int)reader["DriverID"],
                            LicenseClassID = Convert.ToByte(reader["LicenseClassID"]),
                            IssueDate = (DateTime)reader["IssueDate"],
                            ExpirationDate = (DateTime)reader["ExpirationDate"],
                            Notes = reader["Notes"] == DBNull.Value ? string.Empty : (string)reader["Notes"],
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                            IsActive = (bool)reader["IsActive"],
                            IssueReason = Convert.ToByte(reader["IssueReason"]),
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };

                        return dto;
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    // Optionally log the exception here
                    return null;
                }
            }
        }

        public static DataTable GetAllLicenses()
        {
            var dt = new DataTable();
            const string query = "SELECT * FROM Licenses";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    // Optionally log
                }
            }

            return dt;
        }

        public static DataTable GetDriverLicenses(int driverID)
        {
            if (driverID <= 0) return new DataTable();

            var dt = new DataTable();
            const string query = @"
                SELECT Licenses.LicenseID,
                       ApplicationID,
                       LicenseClasses.ClassName,
                       Licenses.IssueDate,
                       Licenses.ExpirationDate,
                       Licenses.IsActive
                FROM Licenses
                INNER JOIN LicenseClasses ON Licenses.LicenseClassID = LicenseClasses.LicenseClassID
                WHERE DriverID = @DriverID
                ORDER BY IsActive DESC, ExpirationDate DESC";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    // Optionally log
                }
            }

            return dt;
        }

        // Insert using DTO
        public static int AddNewLicense(clsLicenseDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.DriverID <= 0) throw new ArgumentException("DriverID must be > 0", nameof(dto.DriverID));
            // other guards may be added

            const string query = @"
                INSERT INTO Licenses
                    (ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                VALUES
                    (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = dto.ApplicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = dto.DriverID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = dto.LicenseClassID;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = dto.IssueDate;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = dto.ExpirationDate;
                if (string.IsNullOrWhiteSpace(dto.Notes))
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = dto.Notes;
                command.Parameters.Add("@PaidFees", SqlDbType.Decimal).Value = dto.PaidFees;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = dto.IsActive;
                command.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = dto.IssueReason;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = dto.CreatedByUserID;

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

                    // Optionally log
                }
            }

            return -1;
        }

        // Update using DTO
        public static bool UpdateLicense(clsLicenseDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.LicenseID <= 0) throw new ArgumentException("LicenseID must be > 0", nameof(dto.LicenseID));

            const string query = @"
                UPDATE Licenses
                SET ApplicationID = @ApplicationID,
                    DriverID = @DriverID,
                    LicenseClassID = @LicenseClassID,
                    IssueDate = @IssueDate,
                    ExpirationDate = @ExpirationDate,
                    Notes = @Notes,
                    PaidFees = @PaidFees,
                    IsActive = @IsActive,
                    IssueReason = @IssueReason,
                    CreatedByUserID = @CreatedByUserID
                WHERE LicenseID = @LicenseID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = dto.LicenseID;
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = dto.ApplicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = dto.DriverID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = dto.LicenseClassID;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = dto.IssueDate;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = dto.ExpirationDate;
                if (string.IsNullOrWhiteSpace(dto.Notes))
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = dto.Notes;
                command.Parameters.Add("@PaidFees", SqlDbType.Decimal).Value = dto.PaidFees;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = dto.IsActive;
                command.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = dto.IssueReason;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = dto.CreatedByUserID;

                try
                {
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                    // Optionally log
                    return false;
                }
            }
        }

        public static int GetActiveLicenseIDByPersonID(int personID, byte? LicenseClassID)
        {
            if (personID <= 0 || LicenseClassID == null) return -1;

            const string query = @"
                SELECT Licenses.LicenseID
                FROM Licenses
                INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID
                WHERE Licenses.LicenseClassID = @LicenseClassID
                  AND Drivers.PersonID = @PersonID
                  AND Licenses.IsActive = 1";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = LicenseClassID;

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

                    // Optionally log
                }
            }

            return -1;
        }
        public static int GetOldLicenseIDByPersonID(int personID, byte? LicenseClassID)
        {
            if (personID <= 0 || LicenseClassID == null) return -1;

            const string query = @"
                SELECT Licenses.LicenseID
                FROM Licenses
                INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID
                WHERE Licenses.LicenseClassID = @LicenseClassID
                  AND Drivers.PersonID = @PersonID
                  AND Licenses.IsActive = 0
                  Order by Licenses.LicenseID desc";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = LicenseClassID;

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

                    // Optionally log
                }
            }

            return -1;
        }

        public static bool DeactivateLicense(int licenseID)
        {
            if (licenseID <= 0) return false;

            const string query = @"
                UPDATE Licenses
                SET IsActive = 0
                WHERE LicenseID = @LicenseID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

                try
                {
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
            {
           
                 clsLogging.LoggingException(ex);

                    // Optionally log
                    return false;
                }
            }
        }
    }
}
