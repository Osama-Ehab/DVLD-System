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

    public class clsTestTypesDataAccess
    {
        public static bool GetTestTypeInfoByID(int ID, ref string Title,ref string Description, ref decimal Fees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestTypesView WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Title = reader["Title"].ToString();
                        Description = reader["Description"].ToString();
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
       
        public static bool GetTestTypeInfoByTitle(string Title, ref int ID, ref string Description, ref decimal Fees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestTypesView WHERE Title = @Title";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", Title);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Title = reader["Title"].ToString();
                        Description = reader["Description"].ToString();
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

        public static bool UpdateTestType(int ID,  string Title,string Description,  decimal Fees)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE TestTypesView
                             SET Title = @Title,
                                 Description = @Description,
                                 Fees = @Fees
                             WHERE ID = @ID;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Description", Description);
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
       
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestTypesView";

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

        public static bool IsTestTypeExist(int ID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Y=1 FROM TestTypesView WHERE ID = @ID";

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

        public static bool IsTestTypeExist(string Title)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT y=1 FROM TestTypesView WHERE Title = @Title";

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

       /* public static int AddNewTestType(int PersonID, string TestTypeName, string Password, bool IsActive)
        {
            int TestTypeID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO TestTypes (PersonID, TestTypeName, Password, IsActive)
                             VALUES (@PersonID, @TestTypeName, @Password, @IsActive);
                             SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@TestTypeName", TestTypeName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int newID))
                    {
                        TestTypeID = newID;
                    }
                }
                catch
                {
                    TestTypeID = -1;
                }
                finally
                { connection.Close(); }
            }

            return TestTypeID;
        }*/
       /* public static bool DeleteTestType(int ID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM TestTypes WHERE TestTypeID = @TestTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestTypeID", ID);

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

