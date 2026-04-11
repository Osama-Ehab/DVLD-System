using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLD_UiLayer.Logging
{
    public static class clsLogging
    {
        private readonly static string sourceName = "DVLD";


        static clsLogging()
        {
            if (EventLog.SourceExists(sourceName)) return;

            EventLog.CreateEventSource(sourceName, "Application");
        }
        public static void LoggingException(Exception ex)
        {
            EventLog.WriteEntry(sourceName, ex.Message);
        }

    }
}
