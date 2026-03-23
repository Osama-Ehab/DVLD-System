using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;


namespace DVLD_BusinessLayer
{
    public class clsPerson
    {
        enum enMode { AddNew,Update};
        public int ID { get; private set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return string.Join(" ", new[] { FirstName, SecondName, ThirdName, LastName }
                    .Where(x => !string.IsNullOrWhiteSpace(x)));
            }
        }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string ImagePath { get; set; }
        private enMode _Mode { get; set; }

        private clsCountries _countryInfo {get;set;}
        public clsCountries CountryInfo
        {
            get
            {
                if (_countryInfo == null && NationalityCountryID > 0)
                    this._countryInfo = clsCountries.Find(NationalityCountryID);
                return _countryInfo;
            }
        }
        public clsPerson()
        {
            this.ID =  -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalityCountryID = -1;
            this.Email = "";
            this.Gender = 0;
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
            _Mode = enMode.AddNew;   
        }

        // -------------------------------------------------------------
        // Operator Overloading: Compare two persons by age.
        //
        // Rules:
        //   - Earlier DateOfBirth  → Older Person
        //   - Later DateOfBirth    → Younger Person
        //
        // Meaning:
        //      a > b  → "a is older than b"
        //      a < b  → "a is younger than b"
        //
        // Null Rules:
        //   - Non-null person is always considered "greater" than null
        //   - Two nulls are considered equal
        // -------------------------------------------------------------

        /// <summary>
        /// Returns true if person a is older than person b.
        /// </summary>
        public static bool operator >(clsPerson a, clsPerson b)
        {
            if (a is null && b is null) return false;
            if (a is null) return false;     // null is never older
            if (b is null) return true;      // valid person is older than null

            return a.DateOfBirth < b.DateOfBirth;
        }

        /// <summary>
        /// Returns true if person a is younger than person b.
        /// </summary>
        public static bool operator <(clsPerson a, clsPerson b)
        {
            if (a is null && b is null) return false;
            if (a is null) return true;      // null treated as infinitely young
            if (b is null) return false;

            return a.DateOfBirth > b.DateOfBirth;
        }

        /// <summary>
        /// Returns true if person a is older than or the same age as person b.
        /// </summary>
        public static bool operator >=(clsPerson a, clsPerson b)
        {
            // a >= b means: older OR same DOB
            return !(a < b);
        }

        /// <summary>
        /// Returns true if person a is younger than or the same age as person b.
        /// </summary>
        public static bool operator <=(clsPerson a, clsPerson b)
        {
            // a <= b means: younger OR same DOB
            return !(a > b);
        }

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName
            , string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
             int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.ImagePath = ImagePath;
            _Mode = enMode.Update;

        }

        private bool _AddNewPerson()
        {
            this.ID = clsPeopleDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                 this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

           return (this.ID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPeopleDataAccess.UpdatePerson(this.ID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                 this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static bool DeletePerson(int ID)
        {
            if (clsPeopleDataAccess.IsPersonExist(ID))
                return clsPeopleDataAccess.DeletePerson(ID);
            else 
                return false;
        }
        
        public static bool IsNationalNoExist(string NationalNo)
        {
            return (clsPeopleDataAccess.IsPersonExist(NationalNo));
        }


        public static clsPerson Find(int ID)
        {
            string FirstName = default, NationalNo = default,SecondName = default, ThirdName = default, LastName = default, Email = default, Phone = default, ImagePath = default, Address = default;
            int  NationalityCountryID = default;
            DateTime DateOfBirth = default;
            byte Gender = default;

            if (clsPeopleDataAccess.GetPersonInfoByID(ID, ref NationalNo, ref FirstName, ref SecondName
            , ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
            ref NationalityCountryID, ref ImagePath))

                return new clsPerson(ID, NationalNo, FirstName, SecondName
            , ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email,
             NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = default,SecondName = default, ThirdName = default, LastName = default, Email = default, Phone = default, ImagePath = default, Address = default;
            int  ID = default , NationalityCountryID = default;
            DateTime DateOfBirth = default;
            byte Gender = default;

            if (clsPeopleDataAccess.GetPersonInfoByNationalNo(NationalNo,ref ID, ref FirstName, ref SecondName
            , ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
            ref NationalityCountryID, ref ImagePath))

                return new clsPerson(ID, NationalNo, FirstName, SecondName
            , ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email,
             NationalityCountryID, ImagePath);
            else
                return null;
        }

        [Range<byte>(18,99,ErrorMessage = "Should be at least 18 years old.")]
        public byte Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;

                // Adjust if birthday hasn't occurred yet this year
                if (DateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }

                return Convert.ToByte(age);
            }

        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;   
                    }
                case enMode.Update:
                    {
                        return _UpdatePerson();
                    }
                default:
                    return false;

            }
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();
        }
        public static bool IsPersonExist(int ID)
        {
            return clsPeopleDataAccess.IsPersonExist(ID);
        }
        public static bool IsPersonExist(string NationalNo)
        {
            return clsPeopleDataAccess.IsPersonExist(NationalNo);
        }

    }
}
