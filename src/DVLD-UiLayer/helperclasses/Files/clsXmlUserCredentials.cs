using System;
using DVLD_UiLayer.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DVLD_BusinessLayer;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.Logging;

namespace DVLD_UiLayer.helperclasses.Files
{
    public static class clsXmlUserCredentials
    {
        private readonly static string filePath = Path.Combine(Application.StartupPath, "user_credentials.xml");

        private static bool LoadUserCredentialsFromFile(string filePath,ref UserCredentials userCredentials)
        {
            if (!File.Exists(filePath))
                return false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserCredentials));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var credentials = (UserCredentials)serializer.Deserialize(reader);
                    if(credentials == null) return false;

                    return true;
                }
            }
            catch
            {
                return false;
                // Ignore errors (e.g., corrupted XML)
            }

            return true;
        }
        private static bool SaveUserCredentials(string filePath, UserCredentials userCredentials)
        {

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserCredentials));
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    serializer.Serialize(writer, userCredentials);
                }
                return true;
            }
            catch (Exception ex)
            {
                clsLogging.LoggingException(ex);
                return clsMessageService.ShowErrorReturnBoolean($"Error saving credentials: {ex.Message}");
            }

            return true;
        }
        private static bool HandleDeleteUserCredentialsFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);
                return clsMessageService.ShowErrorReturnBoolean("Error clearing credentials: " + ex.Message);
            }

            return true;
        }
    }
}
