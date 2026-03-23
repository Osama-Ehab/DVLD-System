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
    public class clsTestType
    {
        enum enMode { AddNew, Update };
        enMode _Mode;

        public  enum enTestType : byte  { VisionTest = 1, WrittenTest, StreetTest }
        public clsTestType.enTestType ID { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        private clsTestType(clsTestType.enTestType ID, string Title,string Description, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            _Mode = enMode.Update;
        }


        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string Title = default, Description = default;
            decimal Fees = default;

            if (clsTestTypesDataAccess.GetTestTypeInfoByID((int)TestTypeID,ref Title,ref Description,ref Fees))

                return new clsTestType(TestTypeID, Title, Description, Fees);
            else
                return null;
        }

        public static clsTestType Find(string Title)
        {
            int TestTypeID = default;
            decimal Fees = default;
            string Description = default;

            if (clsTestTypesDataAccess.GetTestTypeInfoByTitle(Title,ref TestTypeID, ref Description, ref Fees))

                return new clsTestType((clsTestType.enTestType)TestTypeID, Title,Description,Fees);
            else
                return null;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }



        private bool _UpdateTestType()
        {
            return clsTestTypesDataAccess.UpdateTestType((int)this.ID, this.Title,this.Description,this.Fees);
        }

        public static bool IsTestTypeExist(string Title)
        {
            return (clsTestTypesDataAccess.IsTestTypeExist(Title));
        }

        public static bool IsTestTypeExist(clsTestType.enTestType TestTypeID)
        {
            return clsTestTypesDataAccess.IsTestTypeExist((int)TestTypeID);
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
                        return _UpdateTestType();
                    }
                default:
                    return false;

            }
        }
    }

}

