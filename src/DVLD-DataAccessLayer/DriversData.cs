using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    public static class clsDriversDataAccess
    {
        public static clsDriverDTO Find(int driverID)
        {
            if (driverID <= 0) return null;

            const string query = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new clsDriverDTO
                        {
                            DriverID = (int)reader["DriverID"],
                            PersonID = (int)reader["PersonID"],
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public static clsDriverDTO FindByPersonID(int personID)
        {
            if (personID <= 0) return null;

            const string query = @"SELECT * FROM Drivers WHERE PersonID = @PersonID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new clsDriverDTO
                        {
                            DriverID = (int)reader["DriverID"],
                            PersonID = (int)reader["PersonID"],
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public static int AddNewDriver(clsDriverDTO dto)
        {
            if (dto == null || dto.PersonID <= 0 || dto.CreatedByUserID <= 0)
                return -1;

            const string query = @"
                INSERT INTO Drivers (PersonID, CreatedDate, CreatedByUserID)
                VALUES (@PersonID, @CreatedDate, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = dto.PersonID;
                command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = dto.CreatedDate;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = dto.CreatedByUserID;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return (result != null && int.TryParse(result.ToString(), out int newId)) ? newId : -1;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public static bool UpdateDriver(clsDriverDTO dto)
        {
            if (dto == null || dto.DriverID <= 0)
                return false;

            const string query = @"
                UPDATE Drivers
                SET CreatedDate = @CreatedDate,
                    CreatedByUserID = @CreatedByUserID
                WHERE DriverID = @DriverID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = dto.DriverID;
                command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = dto.CreatedDate;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = dto.CreatedByUserID;

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

        public static bool DeleteDriver(int driverID)
        {
            if (driverID <= 0) return false;

            const string query = @"DELETE FROM Drivers WHERE DriverID = @DriverID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

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

        public static int GetDriverIDByPersonID(int personID)
        {
            if (personID <= 0) return -1;

            const string query = "SELECT DriverID FROM Drivers WHERE PersonID = @PersonID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public static bool IsDriverExist(int driverID)
        {
            if (driverID <= 0) return false;

            const string query = "SELECT 1 FROM Drivers WHERE DriverID = @DriverID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

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

        public static bool IsPersonIDExist(int personID)
        {
            if (personID <= 0) return false;

            const string query = "SELECT 1 FROM Drivers WHERE PersonID = @PersonID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

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

        public static DataTable GetAllDrivers()
        {
            const string query = @"SELECT 
                                DriverID AS [Driver ID],
                                PersonID AS [Person ID],
                                NationalNo AS [National No.],
                                CreatedDate AS [Date],
                                FullName AS [Full Name],
                                NumberOfActiveLicenses AS [Active Licenses]
                            FROM Drivers_View;";

            DataTable table = new DataTable();

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
    }
}
