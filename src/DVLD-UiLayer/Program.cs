using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using Microsoft.Extensions.Configuration;
using CryptographyExtensions;
namespace DVLD_UiLayer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Create the configuration builder
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set base path
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Load the JSON file

            IConfiguration configuration = builder.Build(); // Build configuration object
            var ConnectionStringFromConfig = configuration.GetConnectionString("DefaultConnection");
            clsBusinessLogicSettings.Initialize(ConnectionStringFromConfig);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
