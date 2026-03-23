using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.Repository.Settings;
using DVLD_UiLayer.Logging;


namespace DVLD_BusinessLayer
{
    public static class clsBusinessLogicSettings
    {
        private static bool _initialized = false;
        public static void Initialize(string connectionString)
        {
            if (_initialized)
            {
                var invalidOperationException = new InvalidOperationException("ConnectionString is already initialized.");
                clsLogging.LoggingException(invalidOperationException);
                throw invalidOperationException;
            }

            clsDataAccessSettings.Initialize(connectionString);
            _initialized = true;
        }
    }
}
