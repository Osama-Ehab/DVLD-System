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
    public class clsUsersDataAccess
    {
        public static bool GetUserInfoByID(int ID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        PersonID = Convert.ToInt32(reader["PersonID"]);
                        UserName = reader["UserName"]?.ToString();
                        Password = reader["Password"]?.ToString();
                        IsActive = Convert.ToBoolean(reader["IsActive"]);
                        IsFound = true;
                    }

                    reader.Close();
                }
                catch
                {
                    IsFound = false;
                }
                finally
                { connection.Close() ;}
            }

            return IsFound;
        }
        public static bool GetUserInfoByUserName(string UserName,ref int ID, ref int PersonID,ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @UserName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", UserName);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        ID = Convert.ToInt32(reader["UserID"]);
                        PersonID = Convert.ToInt32(reader["PersonID"]);
                        Password = reader["Password"].ToString();
                        IsActive = Convert.ToBoolean(reader["IsActive"]);
                        IsFound = true;
                    }

                    reader.Close();
                }
                catch
                {
                    IsFound = false;
                }
                finally
                { connection.Close() ;}
            }

            return IsFound;
        }

        public static int AddNewUser( int PersonID,  string UserName,  string Password,  bool IsActive)
        {
            int UserID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                             VALUES (@PersonID, @UserName, @Password, @IsActive);
                             SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int newID))
                    {
                        UserID = newID;
                    }
                }
                catch
                {
                    UserID = -1;
                }
                finally
                { connection.Close() ;}
            }

            return UserID;
        }

        public static bool UpdateUser(int ID,  int PersonID,  string UserName,  string Password,  bool IsActive)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users
                             SET PersonID = @PersonID,
                                 UserName = @UserName,
                                 Password = @Password,
                                 IsActive = @IsActive
                             WHERE UserID = @UserID;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

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
                { connection.Close() ;}
            }

            return RowsAffected > 0;
        }

        public static bool DeleteUser(int ID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);

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
                { connection.Close() ;}
            }

            return RowsAffected > 0;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ManageUsers";

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
                { connection.Close() ;}
            }

            return dt;
        }

        public static bool IsUserExist(int ID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Y=1 FROM Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);

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
                { connection.Close() ;}
            }

            return IsFound;
        }

        public static string GetUserPasswordByID(int ID)
        {
            string Password = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Password FROM Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", ID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        Password = result.ToString();
                    }
                }
                catch
                {
                    Password = null;
                }
                finally
                { connection.Close() ;}
            }

            return Password;
        }
        public static bool IsUserExist(string UserName)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Y=1 FROM Users WHERE UserName = @UserName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", UserName);

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
                { connection.Close() ;}
            }

            return IsFound;
        }
        public static bool IsUserNameWithPasswordExistAndIsActive(string UserName,string Password)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Y=1 FROM Users WHERE UserName = @UserName and Password = @Password  and IsActive = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);

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
                { connection.Close() ;}
            }

            return IsFound;
        }
        public static bool IsUserNameWithPasswordExist(string UserName,string Password)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Y=1 FROM Users WHERE UserName = @UserName  and Password = @Password";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);

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
                { connection.Close() ;}
            }

            return IsFound;
        }


        public static bool IsPersonIDExist(int PersonID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Y=1 FROM Users WHERE PersonID = @PersonID ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);


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
                {connection.Close() ;}
            }

            return IsFound;
        }

        public static bool ChangePassword(int UserID,string Password)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users
                             SET Password = @Password
                             WHERE UserID = @UserID;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@Password", Password);

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


    }


}
