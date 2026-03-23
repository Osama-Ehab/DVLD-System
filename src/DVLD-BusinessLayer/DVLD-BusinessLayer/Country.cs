using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsCountries
    {
        public int ID { get; private set; }
        public string CountryName { get; set; }

        private clsCountries(int ID, string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;

        }

    
        public static clsCountries Find(int ID)
        {
            string CountryName = default;

            if (clsCountriesDataAccess.GetCountryInfoByID(ID, ref CountryName))

                return new clsCountries(ID, CountryName);
            else
                return null;
        }

          public static clsCountries Find(string CountryName)
        {
            int CountryID = default;

            if (clsCountriesDataAccess.GetCountryInfoByName(CountryName, ref CountryID))

                return new clsCountries(CountryID, CountryName);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }
    }

}
