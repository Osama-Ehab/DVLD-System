using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DVLD_DataAccessLayer.DTOs;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    public static class clsLicenseClassesDataAccess
    {
        public static clsLicenseClassDTO Find(byte? LicenseClassID)
        {
            if (LicenseClassID == null)
                return null;

            const string query = @"
                SELECT LicenseClassID, ClassName, ClassDescription,
                       MinimumAllowedAge, DefaultValidityLength, ClassFees
                FROM LicenseClasses
                WHERE LicenseClassID = @LicenseClassID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        return new clsLicenseClassDTO
                        {
                            LicenseClassID = Convert.ToByte(reader["LicenseClassID"]),
                            ClassName = reader["ClassName"]?.ToString() ?? string.Empty,
                            ClassDescription = reader["ClassDescription"]?.ToString() ?? string.Empty,
                            MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]),
                            DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]),
                            ClassFees = Convert.ToDecimal(reader["ClassFees"])
                        };
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public static clsLicenseClassDTO FindByName(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                return null;

            const string query = @"
                SELECT LicenseClassID, ClassName, ClassDescription,
                       MinimumAllowedAge, DefaultValidityLength, ClassFees
                FROM LicenseClasses
                WHERE ClassName = @ClassName";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ClassName", SqlDbType.NVarChar, 200).Value = className.Trim();

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        return new clsLicenseClassDTO
                        {
                            LicenseClassID = Convert.ToByte(reader["LicenseClassID"]),
                            ClassName = reader["ClassName"]?.ToString() ?? string.Empty,
                            ClassDescription = reader["ClassDescription"]?.ToString() ?? string.Empty,
                            MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]),
                            DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]),
                            ClassFees = Convert.ToDecimal(reader["ClassFees"])
                        };
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public static byte? AddNewLicenseClass(clsLicenseClassDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.ClassName))
                return null;

			const string query = @"
                INSERT INTO LicenseClasses
                    (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                VALUES
                    (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
                SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ClassName", SqlDbType.NVarChar, 200).Value = dto.ClassName;
                command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar, 1000).Value = (object)dto.ClassDescription ?? DBNull.Value;
                command.Parameters.Add("@MinimumAllowedAge", SqlDbType.TinyInt).Value = dto.MinimumAllowedAge;
                command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt).Value = dto.DefaultValidityLength;

                var feesParam = command.Parameters.Add("@ClassFees", SqlDbType.Decimal);
                feesParam.Precision = 10;
                feesParam.Scale = 2;
                feesParam.Value = dto.ClassFees;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && byte.TryParse(result.ToString(), out byte newId))
                        return newId;
                    else
                        return null;
                }
                catch
                {
                    return null ;
                }
            }
        }

        public static bool UpdateLicenseClass(clsLicenseClassDTO dto)
        {
            if (dto == null || dto.LicenseClassID == null)
                return false;

            const string query = @"
                UPDATE LicenseClasses
                SET ClassName = @ClassName,
                    ClassDescription = @ClassDescription,
                    MinimumAllowedAge = @MinimumAllowedAge,
                    DefaultValidityLength = @DefaultValidityLength,
                    ClassFees = @ClassFees
                WHERE LicenseClassID = @LicenseClassID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = dto.LicenseClassID;
                command.Parameters.Add("@ClassName", SqlDbType.NVarChar, 200).Value = dto.ClassName;
                command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar, 1000).Value = (object)dto.ClassDescription ?? DBNull.Value;
                command.Parameters.Add("@MinimumAllowedAge", SqlDbType.TinyInt).Value = dto.MinimumAllowedAge;
                command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt).Value = dto.DefaultValidityLength;

                var feesParam = command.Parameters.Add("@ClassFees", SqlDbType.Decimal);
                feesParam.Precision = 10;
                feesParam.Scale = 2;
                feesParam.Value = dto.ClassFees;

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

        public static bool DeleteLicenseClass(byte? LicenseClassID)
        {
            if (LicenseClassID == null)
                return false;

            const string query = "DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

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

        public static bool IsExist(byte? LicenseClassID)
        {
            if (LicenseClassID == null)
                return false;

            const string query = "SELECT 1 FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

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

        public static DataTable GetAllLicenseClasses()
        {
            const string query = @"
                SELECT 
                    LicenseClassID AS [LicenseClassID],
                    ClassName AS [ClassName],
                    ClassDescription AS [ClassDescription],
                    MinimumAllowedAge AS [MinimumAllowedAge],
                    DefaultValidityLength AS [DefaultValidityLength],
                    ClassFees AS [ClassFees]
                FROM LicenseClasses
                ORDER BY ClassName";

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
                    // Optional: log error
                }
            }

            return table;
        }
    }
}
