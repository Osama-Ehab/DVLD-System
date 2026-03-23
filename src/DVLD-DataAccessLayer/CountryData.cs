using System;
using DVLD_UiLayer.Logging;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    public class clsCountriesDataAccess
    {
        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries Where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);
        
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    CountryName = (string)reader["CountryName"];                 
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                IsFound = false;
            }
            finally
            { connection.Close(); }


            return IsFound;
        }


        public static DataTable GetAllCountries()
        {
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries order by CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Dt.Load(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                
            }
            finally
            { connection.Close(); }


            return Dt;
        }


        public static bool GetCountryInfoByName(string CountryName , ref int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries Where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ID = (int)reader["CountryID"];              
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                IsFound = false;
            }
            finally
            { connection.Close(); }


            return IsFound;
        }

    }
}

//public static int AddNewCountry(string CountryName)
//{
//    int CountryID = -1;
//    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

//    string query = @"INSERT INTO Countries
//                     VALUES (@CountryName,@Code,@PhoneCode)
//                     Select SCOPE_IDENTITY()";

//    SqlCommand command = new SqlCommand(query, connection);
//    command.Parameters.AddWithValue("@CountryName", CountryName);
//    if (Code == "")
//        command.Parameters.AddWithValue("@Code", System.DBNull.Value);
//    else
//        command.Parameters.AddWithValue("@Code", Code);
//    if (PhoneCode == "")
//        command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);
//    else
//        command.Parameters.AddWithValue("@PhoneCode", PhoneCode);


//    try
//    {
//        connection.Open();

//        Object Result = command.ExecuteScalar();
//        if (Result != null && int.TryParse(Result.ToString(), out int ID))
//            CountryID = ID;
//    }
//    catch (Exception ex)
//    {
//        CountryID = -1;
//    }
//    finally
//    { connection.Close(); }

//    return CountryID;
//}
/*
public static bool UpdateCountry(int ID, string CountryName, string Code, string PhoneCode)
{
    int RowsAffected = 0;

    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

    string query = @"Update Countries
                         set [CountryName] = @CountryName,
                         set [Code] = @Code,
                         set [PhoneCode] = @PhoneCode
                         Where CountryID = @CountryID;";


    SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@CountryID", ID);
    command.Parameters.AddWithValue("@CountryName", CountryName);
    if (Code == "")
        command.Parameters.AddWithValue("@Code", System.DBNull.Value);
    else
        command.Parameters.AddWithValue("@Code", Code);
    if (PhoneCode == "")
        command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);
    else
        command.Parameters.AddWithValue("@PhoneCode", PhoneCode);



    try
    {
        connection.Open();

        RowsAffected = command.ExecuteNonQuery();

    }


    catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

        return false;
    }
    finally { connection.Close(); }

    return (RowsAffected > 0);
}*/
/*        public static bool IsCountryExist(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Y=1 FROM Countries Where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();

                IsFound = (command.ExecuteScalar() != null) ? true : false;
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                IsFound = false;
            }
            finally
            { connection.Close(); }


            return IsFound;
        }
*/

/*        public static bool IsCountryExist(string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Y=1 FROM Countries Where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                IsFound = (command.ExecuteScalar() != null) ? true : false;
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                IsFound = false;
            }
            finally
            { connection.Close(); }


            return IsFound;
        }
*/

/*

        public static bool DeleteCountry(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete Countries
                         Where CountryID = @CountryID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();

            }


            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                return false;
            }
            finally { connection.Close(); }

            return (RowsAffected > 0);
        }

*/