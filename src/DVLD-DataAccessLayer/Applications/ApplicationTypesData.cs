using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.Repository.Settings;


namespace DVLD_DataAccessLayer
{

    public class clsApplicationTypesDataAccess
    {
        public static bool GetApplicationTypeInfoByID(byte ID, ref string Title, ref decimal Fees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypesView WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Title = reader["Title"].ToString();
                        Fees = Convert.ToDecimal(reader["Fees"]);
                        IsFound = true;
                    }

                    reader.Close();
                }
                catch
                {
                    IsFound = false;
                }
                finally
                { connection.Close(); }
            }

            return IsFound;
        }
       
        public static bool GetApplicationTypeInfoByTitle(string Title, ref byte ID, ref decimal Fees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypesView WHERE Title = @Title";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", Title);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Title = reader["Title"].ToString();
                        Fees = Convert.ToDecimal(reader["Fees"]);
                        IsFound = true;
                    }

                    reader.Close();
                }
                catch
                {
                    IsFound = false;
                }
                finally
                { connection.Close(); }
            }

            return IsFound;
        }

        public static bool UpdateApplicationType(byte ID,  string Title,  decimal Fees)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE ApplicationTypesView
                             SET Title = @Title,
                                 Fees = @Fees
                             WHERE ID = @ID;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Fees", Fees);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                finally
                { connection.Close(); }
            }

            return RowsAffected > 0;
        }
       
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypesView";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                    reader.Close();
                }
                catch
                {
                    // Log error
                }
                finally
                { connection.Close(); }
            }

            return dt;
        }

        public static bool IsApplicationTypeExist(byte ID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Y=1 FROM ApplicationTypesView WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();
                    IsFound = (command.ExecuteScalar() != null);
                }
                catch
                {
                    IsFound = false;
                }
                finally
                { connection.Close(); }
            }

            return IsFound;
        }

        public static bool IsApplicationTypeExist(string Title)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT y=1 FROM ApplicationTypesView WHERE Title = @Title";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", Title);

                try
                {
                    connection.Open();
                    IsFound = (command.ExecuteScalar() != null);
                }
                catch
                {
                    IsFound = false;
                }
                finally
                { connection.Close(); }
            }

            return IsFound;
        }

       /* public static int AddNewApplicationType(int PersonID, string ApplicationTypeName, string Password, bool IsActive)
        {
            int ApplicationTypeID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO ApplicationTypes (PersonID, ApplicationTypeName, Password, IsActive)
                             VALUES (@PersonID, @ApplicationTypeName, @Password, @IsActive);
                             SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@ApplicationTypeName", ApplicationTypeName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int newID))
                    {
                        ApplicationTypeID = newID;
                    }
                }
                catch
                {
                    ApplicationTypeID = -1;
                }
                finally
                { connection.Close(); }
            }

            return ApplicationTypeID;
        }*/
       /* public static bool DeleteApplicationType(byte ID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationTypeID", ID);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                finally
                { connection.Close(); }
            }

            return RowsAffected > 0;
        }*/


    }


}

