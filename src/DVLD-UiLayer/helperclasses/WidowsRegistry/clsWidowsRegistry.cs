using System;
using DVLD_UiLayer.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;
using Microsoft.Win32;

namespace DVLD_UiLayer.helperclasses.WidowsRegistry
{
    public static class clsWidowsRegistry
    {
        private static readonly string BaseKeyPath = @"HKEY_CURRENT_USER\Software\DVLD";
        private static readonly string SubKeyPath = @"Software\DVLD";
        private static readonly string ValueNameOfUsername = "Username";
        private static readonly string PasswordValueName = "Password";    
        public static bool SaveUserCredentials(UserCredentials userCredentials)
        {
            if (userCredentials == null || userCredentials.Username == null || userCredentials.Password == null) return false;

            try
            {
                if (!EnableRememberMe()) return false;
                Registry.SetValue(BaseKeyPath, ValueNameOfUsername, userCredentials.Username, RegistryValueKind.String);
                Registry.SetValue(BaseKeyPath, PasswordValueName, userCredentials.Password, RegistryValueKind.String);
                return true;                
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                //We will making logging class in the future;
                return false;
            }

            return false;

        }
        public static bool GetUserCredentials(ref string username, ref string password)
        {
            if (!IsRememberMeEnabled()) return false;

            try
            {
                username = Registry.GetValue(BaseKeyPath, ValueNameOfUsername, null) as string;
                password = Registry.GetValue(BaseKeyPath, PasswordValueName, null) as string;
                if (username == null || password == null) return false;

                return true;                
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                //We will making logging class in the future;
                return false;
            }

            return false;

        }

        public static bool EnableRememberMe()
        {
            string ValueName = "RememberCredentials";
            try
            {
                Registry.SetValue(BaseKeyPath, ValueName, true, RegistryValueKind.DWord);
                return true;
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                //We will making logging class in the future;
                return false;
            }

            return false;
        }
        public static bool DisableRememberMe()
        {
            string ValueName  = "RememberCredentials";
            try
            {
                Registry.SetValue(BaseKeyPath, ValueName, false, RegistryValueKind.DWord);
                return true;
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                //We will making logging class in the future;
                return false;
            }

            return false;

        }
        public static bool ClearUserCredentials()
        {

            if (!DisableRememberMe()) return false;

            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(SubKeyPath, true))
                    {
                        if (key == null) return false;

                        // Delete the specified value
                        key.DeleteValue(ValueNameOfUsername);
                        key.DeleteValue(PasswordValueName);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                return false;
            }
            return false;
        

        }
        public static bool IsRememberMeEnabled()
        {
            string ValueName  = "RememberCredentials";
            try
            {
                return Convert.ToBoolean(Registry.GetValue(BaseKeyPath, ValueName, false));
            }
            catch (Exception ex)
            {
           
                clsLogging.LoggingException(ex);

                //We will making logging class in the future;
                return false;
            }

            return false;

        }


     


    }
}
