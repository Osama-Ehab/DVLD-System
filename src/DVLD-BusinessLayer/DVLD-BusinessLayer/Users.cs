using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using CryptographyExtensions;


namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        enum enMode { AddNew, Update };
        public int UserID { get; private set; }
        public string UserName { get; set; }
        public int PersonID { get; set; }

        [Range<int>(8,20)]
        public string Password { get; set; }      
        public bool IsActive { get; set; }  
        private enMode _Mode { get; set; }

        private clsPerson _personInfo { get; set; }
        public clsPerson PersonInfo
        {
            get
            {
                if (_personInfo == null && PersonID > 0)
                    this._personInfo = clsPerson.Find(PersonID);
                return _personInfo;
            }
        }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";     
            this.Password = null;
            this.IsActive = false;
            _Mode = enMode.AddNew;
        }

        private clsUser(int ID,int PersonID, string UserName, string Password,bool IsActive)
        {
            this.UserID = ID;
            this.UserName = UserName;
            this.PersonID = PersonID; 
            this.Password = Password;         
            this.IsActive = IsActive;
            _Mode = enMode.Update;

        }

        private bool _AddNewUser()
        {
            this.UserID =  clsUsersDataAccess.AddNewUser(this.PersonID, this.UserName, 
                 this.Password.Hashing(), this.IsActive);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUsersDataAccess.UpdateUser(this.UserID,this.PersonID, this.UserName
                , this.Password.Hashing(), this.IsActive);
        }

        public static bool DeleteUser(int ID)
        {
            if (clsUsersDataAccess.IsUserExist(ID))
                return clsUsersDataAccess.DeleteUser(ID);
            else
                return false;
        }

        public static bool  IsUserNameExist(string UserName)
        {
            return (clsUsersDataAccess.IsUserExist(UserName));
        }

        public static string GetHashedUserPassword(int ID)
        {
            if (clsUsersDataAccess.IsUserExist(ID))
                return clsUsersDataAccess.GetUserPasswordByID(ID);
            else
                return null;
        }

        public static clsUser Find(int ID)
        {
            string  Password = default,UserName = default;
            int PersonID = default;
            bool IsActive = default;

            if (clsUsersDataAccess.GetUserInfoByID(ID,ref PersonID, ref UserName,
                ref Password, ref IsActive))

                return new clsUser(ID, PersonID ,UserName
                    , Password,IsActive);
            else
                return null;
        }

        public static clsUser Find(string UserName)
        {
            int ID = default, PersonID = default;
            string Password = default;
            bool IsActive = default;

            if (clsUsersDataAccess.GetUserInfoByUserName(UserName, ref ID,ref PersonID
                ,ref Password,ref IsActive))

                return new clsUser(ID,PersonID, UserName
                    , Password,IsActive);
            else
                return null;
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateUser();
                    }
                default:
                    return false;

            }
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }
        public static bool IsUserExist(int ID)
        {
            return clsUsersDataAccess.IsUserExist(ID);
        }  
        
        public static bool IsUserNameWithPasswordExistAndIsActive(string UserName,string Password)
        {
            return clsUsersDataAccess.IsUserNameWithPasswordExistAndIsActive(UserName, Password.Hashing());
        }
              
        public static bool IsUserNameWithPasswordExist(string UserName,string Password)
        {
            return clsUsersDataAccess.IsUserNameWithPasswordExist(UserName, Password.Hashing());
        }
        public static bool IsPersonIDExist(int PersonID)
        {

            return clsUsersDataAccess.IsPersonIDExist(PersonID);
        }

        public bool ChangePassword(string NewPassword)
        {
            if (!clsUsersDataAccess.ChangePassword(this.UserID, NewPassword.Hashing())) return false;
            
            this.Password = NewPassword;
            return true;
        }
    }
}
