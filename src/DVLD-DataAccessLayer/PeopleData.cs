using System;
using DVLD_UiLayer.Logging;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.Repository.Settings;

namespace DVLD_DataAccessLayer
{
    //public enum enGender {Male,Female };
    //public enGender Gender;
    public class clsPeopleDataAccess
    {
        public static bool GetPersonInfoByID(int ID,ref string NationalNo,ref string FirstName, ref string SecondName
            , ref string ThirdName ,ref string LastName,ref DateTime DateOfBirth,ref byte Gender, ref string Address, ref string Phone,ref string Email,
            ref int NationalityCountryID,ref string ImagePath) 
        {
            bool IsFound = false;

            SqlConnection connection  = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];  

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = reader["ThirdName"].ToString();
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = Convert.ToByte(reader["Gender"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        Email = reader["Email"].ToString();
                    else
                        Email = "";
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = reader["ImagePath"].ToString();
                    else 
                        ImagePath = "";
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


        public static bool GetPersonInfoByNationalNo(string NationalNo,ref int ID,ref string FirstName, ref string SecondName
            , ref string ThirdName ,ref string LastName,ref DateTime DateOfBirth,ref byte Gender, ref string Address, ref string Phone,ref string Email,
            ref int NationalityCountryID,ref string ImagePath) 
        {
            bool IsFound = false;

            SqlConnection connection  = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People Where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ID = Convert.ToInt32(reader["PersonID"]);
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];


                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = reader["ThirdName"].ToString();
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = Convert.ToByte(reader["Gender"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (reader["Email"] != DBNull.Value) ? reader["Email"].ToString() : "";
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = reader["ImagePath"].ToString();
                    else 
                        ImagePath = "";

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



        public static int AddNewPerson( string NationalNo,  string FirstName,  string SecondName
            ,  string ThirdName,  string LastName,  DateTime DateOfBirth,  byte Gender,  string Address,  string Phone,  string Email,
             int NationalityCountryID,  string ImagePath)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People ([NationalNo],[FirstName],[SecondName],[ThirdName],[LastName]
                         ,[DateOfBirth],[Gender],[Address],[Phone],[Email]
                         ,[NationalityCountryID],[ImagePath])
                         VALUES (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath)
                             Select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);
            
            
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                Object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                    PersonID = ID;
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                PersonID = -1;
            }
            finally
            { connection.Close(); }

            return PersonID;
        }

        public static bool UpdatePerson(int ID,string NationalNo, string FirstName, string SecondName
            , string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
             int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update People
                         set [NationalNo] = @NationalNo
                            ,[FirstName] = @FirstName
                            ,[SecondName] = @SecondName
                            ,[ThirdName] = @ThirdName
                            ,[LastName] = @LastName
                            ,[DateOfBirth] = @DateOfBirth
                            ,[Gender] = @Gender
                            ,[Address] = @Address
                            ,[Phone] = @Phone
                            ,[Email] = @Email
                            ,[NationalityCountryID] = @NationalityCountryID
                            ,[ImagePath] = @ImagePath
                         Where PersonID = @PersonID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
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
        
               
        public static bool DeletePerson(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete People
                         Where PersonID = @PersonID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);

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


        public static DataTable GetAllPeople()
        {
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ManagePeople";

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

        public static bool IsPersonExist(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Y=1 FROM People Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();

                IsFound = (command.ExecuteScalar() != null) ;
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
        
        
        public static bool IsPersonExist(string NationalNo)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Y=1 FROM People Where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                IsFound = (command.ExecuteScalar() != null) ;
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
