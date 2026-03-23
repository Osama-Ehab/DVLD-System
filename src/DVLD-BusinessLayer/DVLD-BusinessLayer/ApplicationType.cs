using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Xml.Linq;

namespace DVLD_BusinessLayer
{
    public class clsApplicationType
    {
        enum enMode { AddNew, Update };
        enMode _Mode;
        public byte ID { get; private set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        private clsApplicationType(byte ID, string Title, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
            _Mode = enMode.Update;
        }


        public static clsApplicationType Find(byte ID)
        {
            string Title = default;
            decimal Fees = default;

            if (clsApplicationTypesDataAccess.GetApplicationTypeInfoByID(ID,ref Title,ref Fees))

                return new clsApplicationType(ID,Title, Fees);
            else
                return null;
        }

        public static clsApplicationType Find(string Title)
        {
            byte ID = default;
            decimal Fees = default;

            if (clsApplicationTypesDataAccess.GetApplicationTypeInfoByTitle(Title,ref ID, ref Fees))

                return new clsApplicationType( ID,Title,Fees);
            else
                return null;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }



        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesDataAccess.UpdateApplicationType(this.ID, this.Title,this.Fees);
        }

        public static bool IsApplicationTypeExist(string Title)
        {
            return (clsApplicationTypesDataAccess.IsApplicationTypeExist(Title));
        }

        public static bool IsApplicationTypeExist(byte ID)
        {
            return clsApplicationTypesDataAccess.IsApplicationTypeExist(ID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        //if (_AddNewUser())
                        //{
                        //    _Mode = enMode.Update;
                        //    return true;
                        //}
                        //else
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateApplicationType();
                    }
                default:
                    return false;

            }
        }
    }

}

