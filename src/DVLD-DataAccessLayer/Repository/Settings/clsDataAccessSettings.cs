using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using DVLD_UiLayer.Logging;
using Microsoft.Extensions.Configuration;
namespace DVLD_DataAccessLayer.Repository.Settings
{
    public static class clsDataAccessSettings
    {
        private static bool _initialized = false;
        public static string? ConnectionString { get; private set; }

        public static void Initialize(string connectionString)
        {
            if (_initialized)
            {
                var invalidOperationException = new InvalidOperationException("ConnectionString is already initialized.");
                clsLogging.LoggingException(invalidOperationException);
                throw invalidOperationException;
            }
               

            ConnectionString = connectionString;
            _initialized = true;
        }
    }
}
